using BehaviorTree;
using System.Collections.Generic;
using UnityEngine;

public class AttackTask : Node
{
    private readonly Transform npcTransform;
    private Transform playerTransform;
    private readonly Animator animator;
    private readonly Weapon weapon;
    private readonly Rigidbody rb;

    private readonly float detectionRadius;
    private readonly float rotationSpeed;
    private readonly float attackRange;
    private readonly float moveSpeed;
    private readonly float comboInterval;
    private readonly float comboResetDelay;
    private readonly IReadOnlyList<AttackSO> combo;

    private float lastComboTriggerTime;
    private float lastComboEndTime;
    private int comboIndex;

    public AttackTask(
        Transform npcTransform,
        Transform playerTransform,
        float detectionRadius,
        float rotationSpeed,
        float attackRange,
        float moveSpeed,
        float comboInterval,
        float comboResetDelay,
        IReadOnlyList<AttackSO> combo)
    {
        this.npcTransform = npcTransform;
        this.playerTransform = playerTransform;
        this.detectionRadius = Mathf.Max(0f, detectionRadius);
        this.rotationSpeed = rotationSpeed;
        this.attackRange = Mathf.Max(0.1f, attackRange);
        this.moveSpeed = Mathf.Max(0f, moveSpeed);
        this.comboInterval = Mathf.Max(0f, comboInterval);
        this.comboResetDelay = Mathf.Max(0f, comboResetDelay);
        this.combo = combo;

        animator = npcTransform.GetComponent<Animator>();
        weapon = npcTransform.GetComponentInChildren<Weapon>();
        rb = npcTransform.GetComponent<Rigidbody>();

        CachePlayerIfMissing();
    }

    public override NodeState Evaluate()
    {
        CachePlayerIfMissing();
        if (playerTransform == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        float distance = Vector3.Distance(npcTransform.position, playerTransform.position);
        if (distance > detectionRadius)
        {
            state = NodeState.FAILURE;
            return state;
        }

        FacePlayer();

        if (distance > attackRange)
        {
            MoveTowardsPlayer();
            state = NodeState.RUNNING;
            return state;
        }

        StopMovement();
        HandleComboAttacks();
        state = NodeState.RUNNING;
        return state;
    }

    private void CachePlayerIfMissing()
    {
        if (playerTransform != null)
        {
            return;
        }

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    private void FacePlayer()
    {
        if (playerTransform == null)
        {
            return;
        }

        Vector3 direction = playerTransform.position - npcTransform.position;
        direction.y = 0f;
        if (direction.sqrMagnitude <= Mathf.Epsilon)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        npcTransform.rotation = Quaternion.Slerp(npcTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    private void MoveTowardsPlayer()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", moveSpeed);
        }

        if (playerTransform == null)
        {
            return;
        }

        Vector3 newPosition = Vector3.MoveTowards(npcTransform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        if (rb != null)
        {
            rb.MovePosition(newPosition);
        }
        else
        {
            npcTransform.position = newPosition;
        }
    }

    private void StopMovement()
    {
        if (animator != null)
        {
            animator.SetFloat("Speed", 0f);
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void HandleComboAttacks()
    {
        if (animator == null)
        {
            return;
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsTag("Attack"))
        {
            if (stateInfo.normalizedTime >= 0.98f)
            {
                lastComboEndTime = Time.time;
            }
            return;
        }

        if (combo == null || combo.Count == 0)
        {
            animator.Play("Attack", 0, 0f);
            return;
        }

        if (Time.time - lastComboEndTime > comboResetDelay)
        {
            comboIndex = 0;
        }

        if (Time.time - lastComboTriggerTime < comboInterval)
        {
            return;
        }

        TriggerComboStrike(combo[comboIndex]);
        comboIndex = (comboIndex + 1) % combo.Count;
        lastComboTriggerTime = Time.time;
    }

    private void TriggerComboStrike(AttackSO attackData)
    {
        if (animator == null)
        {
            return;
        }

        if (attackData != null && attackData.animatorOV != null)
        {
            animator.runtimeAnimatorController = attackData.animatorOV;
        }

        animator.Play("Attack", 0, 0f);

        if (weapon != null && attackData != null)
        {
            weapon.SetDamage(Mathf.RoundToInt(attackData.damage));
        }
    }
}
