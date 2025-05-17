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
        if (isWaiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
                isWaiting = false;
        }
        else
        {
            Transform wp = patrolPoints[currentPatrolIndex];
            if (Vector3.Distance(playerPos.position, wp.position) < 0.1f)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                playerPos.position = wp.position;
                isWaiting = true;
                waitTimer = 0f;
            }
            else
            {
                playerPos.position = Vector3.MoveTowards(playerPos.position, wp.position, patrolSpeed * Time.deltaTime);
                playerPos.LookAt(wp.position);
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
