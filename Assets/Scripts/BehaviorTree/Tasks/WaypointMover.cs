using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    private Transform currentWaypoint= null;
    void Start()
    {
        // Initialize the current waypoint to the first one in the list\
        currentWaypoint = waypoints.NextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
