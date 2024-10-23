using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;


    // Called when another collider enters this trigger collider
    private void OnTriggerEnter(Collider collider)
    {
        // Check if the collider has a Health component
        Health health = collider.GetComponent<Health>();
        if (health != null)
        {
            // Apply damage to the health component
            health.Damage(damage);
        }
    }
}
