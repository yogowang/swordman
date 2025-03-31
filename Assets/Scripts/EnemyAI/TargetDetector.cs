using System;
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
    public float detectionRadius = 5f; // Detection radius
    private float distance=0f;

    void Update()
    {
        if (player != null)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            //Debug.Log($"Distance to player: {distance}");
        }
    else
        {
            Debug.LogWarning("Player is null in Update!");
        }
    }
    public Boolean ifWithinDetectDistance(){
        return distance>detectionRadius ? false : true;
    }
}
