using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(player==null){
            player=GameObject.FindWithTag("Player");
        }
        distance=Vector3.Distance(transform.position,player.transform.position);
    }

    public GameObject player; // Assign this in the Unity Editor
    private float detectionRadius = 10f; // Detection radius
    private float distance=0f;

    void Update()
    {
        distance=Vector3.Distance(transform.position,player.transform.position);
    }
    public GameObject ifWithinDetectDistance(){
        return distance>detectionRadius ? null : player;
    }
}
