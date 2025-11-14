using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class GuardBT : TreeCustom
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private float rotationSpeedWhileAttacking = 10f;

    protected override Node SetupTree()
    {
        if (waypoints != null)
        {
            transform.position = waypoints.NextWaypoint(null).position;
        }

        Transform playerTransform = GameObject.FindWithTag("Player")?.transform;

        Node attackNode = new AttackTask(transform, playerTransform, detectionRadius, rotationSpeedWhileAttacking);
        Node patrolNode = new PatrolTask(transform, waypoints);

        Node root = new Selector(new List<Node>
        {
            attackNode,
            patrolNode
        });

        return root;
    }
}
