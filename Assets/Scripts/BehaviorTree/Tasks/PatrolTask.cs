using BehaviorTree;
using UnityEditor.Rendering;
using UnityEngine;

public class PatrolTask : Node
{
    private Transform dummyPos;
    [SerializeField]private float stopDistance = 1f;

    private Waypoints waypoints;
    private Transform currentWaypoint=null;

    private float patrolSpeed = 20f;
    private float waitTime = 1f;
    private float waitTimer = 0f;
    private bool isWaiting = false;
    private Animator animator;
    private Rigidbody rb;
    public PatrolTask(Transform dummyPos, Waypoints waypoints)
    {
        this.dummyPos = dummyPos;
        this.waypoints = waypoints;
        animator = dummyPos.GetComponent<Animator>();
        rb = dummyPos.GetComponent<Rigidbody>();
        currentWaypoint = waypoints.NextWaypoint(currentWaypoint);

    }
    public override NodeState Evaluate()
    {
        if (isWaiting)
        {
            currentWaypoint = waypoints.NextWaypoint(currentWaypoint);
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
                isWaiting = false;
        }
        else
        {
            if (Vector3.Distance(dummyPos.position, currentWaypoint.position) < stopDistance)
            {
                //currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                //dummyPos.position = wp.position;
                animator.SetFloat("Speed", 0f); // Stop animation when waiting
                isWaiting = true;
                waitTimer = 0f;
            }
            else
            {
                animator.SetFloat("Speed", patrolSpeed); // Set animation speed
                Vector3 newPosition = Vector3.MoveTowards(dummyPos.position, currentWaypoint.position, patrolSpeed * Time.deltaTime);
                dummyPos.LookAt(currentWaypoint.position);
                rb.MovePosition(newPosition); // Move the dummy position
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
