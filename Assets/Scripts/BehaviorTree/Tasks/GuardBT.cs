
using BehaviorTree;
public class GuardBT : TreeCustom
{
    
    public Waypoints waypoints;
    public static float speed = 2f;
    protected override Node SetupTree()
    {
        Node root = new PatrolTask(transform, waypoints);
        return root;
    }
}
