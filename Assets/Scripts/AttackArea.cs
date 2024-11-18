using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage;


    // Called when another collider enters this trigger collider
    private void OnTriggerEnter(Collider collider)
    {
        // Check if the collider has a Health component
        //Health health = collider.GetComponent<Health>();
        Health health = collider.GetComponentInParent<Health>();
        if (health != null)
        {
            // Apply damage to the health component
            health.Damage(damage);
             Debug.Log("Dummy hit! Health reduced by " + damage);
        }
    }
    // Public method to set the damage
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
