using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    void Start()
    {
         player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
}
