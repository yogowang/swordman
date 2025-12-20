using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class GuardBT : TreeCustom
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private EnemyTemplateSO template;

    protected override Node SetupTree()
    {
        if (waypoints != null)
        {
            transform.position = waypoints.NextWaypoint(null).position;
        }

        Transform playerTransform = GameObject.FindWithTag("Player")?.transform;

        float detectionRadius = template != null ? template.detectionRadius : 5f;
        float rotationSpeedWhileAttacking = template != null ? template.rotationSpeedWhileAttacking : 10f;
        float attackRange = template != null ? template.attackRange : 1.5f;
        float chaseSpeed = template != null ? template.chaseSpeed : 4f;
        float comboInterval = template != null ? template.comboInterval : 0.3f;
        float comboResetDelay = template != null ? template.comboResetDelay : 1f;
        List<AttackSO> comboSequence = template != null ? template.comboSequence : null;

        Node attackNode = new AttackTask(
            transform,
            playerTransform,
            detectionRadius,
            rotationSpeedWhileAttacking,
            attackRange,
            chaseSpeed,
            comboInterval,
            comboResetDelay,
            comboSequence);
        Node patrolNode = new PatrolTask(transform, waypoints);

        Node root = new Selector(new List<Node>
        {
            attackNode,
            patrolNode
        });

        return root;
    }
}
