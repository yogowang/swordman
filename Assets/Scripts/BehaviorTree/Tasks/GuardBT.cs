
using BehaviorTree;
public class GuardBT : Tree
{
    public UnityEngine.Transform[] patrolPoints;
    public static float speed = 2f;
    protected override Node SetupTree()
    {
        Node root = new PatrolTask(transform, patrolPoints);
        return root;
    }
}
