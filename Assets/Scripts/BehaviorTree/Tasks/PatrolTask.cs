using BehaviorTree;
using UnityEngine;

public class PatrolTask : Node
{
    private Transform dummyPos;
    private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    private float patrolSpeed = 2f;
    private float waitTime = 1f;
    private float waitTimer = 0f;
    private bool isWaiting = false;
    private Animator animator;
    private Rigidbody rb;
    public PatrolTask(Transform dummyPos, Transform[] patrolPoints)
    {
        this.dummyPos = dummyPos;
        this.patrolPoints = patrolPoints;
        animator = dummyPos.GetComponent<Animator>();
        rb = dummyPos.GetComponent<Rigidbody>();

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
            if (Vector3.Distance(dummyPos.position, wp.position) < 0.1f)
            {
                currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                //dummyPos.position = wp.position;
                animator.SetFloat("Speed", 0f); // Stop animation when waiting
                isWaiting = true;
                waitTimer = 0f;
            }
            else
            {
                animator.SetFloat("Speed", patrolSpeed); // Set animation speed
                Vector3 newPosition = Vector3.MoveTowards(dummyPos.position, wp.position, patrolSpeed * Time.deltaTime);
                dummyPos.LookAt(wp.position);
                rb.MovePosition(newPosition); // Move the dummy position
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}
