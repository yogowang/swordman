using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public Transform player; // Assign this in the Unity Editor
    public float detectionRadius = 10f; // Detection radius
    public LayerMask playerLayer; // Layer mask to detect only player objects

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        // Check for player within the detection radius
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            Debug.Log("Player detected");
            // Additional logic for when the player is detected
        }
    }
}
