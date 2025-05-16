using BehaviorTree;
using UnityEngine;

public class PatrolTask : Node
{
    private Transform playerPos;
    private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    private float patrolSpeed = 2f;
    private float waitTime = 1f;
    private float waitTimer = 0f;
    private bool isWaiting = false;
    public PatrolTask(Transform playerPos, Transform[] patrolPoints) 
    {
        this.playerPos = playerPos;
        this.patrolPoints = patrolPoints;

    }
    public override NodeState Evaluate()
    {
        
        return base.Evaluate();
    }
}
