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
    float lastComboEnd;
    int comboCounter;

    [SerializeField] private List<AttackSO> combo; 

    private readonly float detectionRadius;
    
    private readonly float rotationSpeed;

    public AttackTask(Transform npcTransform, Transform playerTransform, float detectionRadius,  float rotationSpeed = 10f)
    {
        this.npcTransform = npcTransform;
        this.playerTransform = playerTransform;
        this.detectionRadius = detectionRadius;
        this.rotationSpeed = rotationSpeed;

        animator = npcTransform.GetComponent<Animator>();
        weapon = npcTransform.GetComponentInChildren<Weapon>();
        rb = npcTransform.GetComponent<Rigidbody>();

        if (this.playerTransform == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                this.playerTransform = playerObject.transform;
            }
        }
    }

    public override NodeState Evaluate()
    {
        if (playerTransform == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        float sqrDistance = (npcTransform.position - playerTransform.position).sqrMagnitude;
        if (sqrDistance > detectionRadius * detectionRadius)
        {
            state = NodeState.FAILURE;
            return state;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }

        Vector3 direction = playerTransform.position - npcTransform.position;
        direction.y = 0f;
        if (direction.sqrMagnitude > Mathf.Epsilon)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            npcTransform.rotation = Quaternion.Slerp(npcTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        if (animator != null)
        {
            animator.SetFloat("Speed", 0f);
            if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
              animator.Play("Attack", 0, 0);
            }
        }


        state = NodeState.RUNNING;
        return state;
    }
}
