using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   private int damage;
    BoxCollider triggerBox;
    CapsuleCollider capsuleCollider;

    private void Start()
    {
        triggerBox = GetComponent<BoxCollider>();
        capsuleCollider=GetComponent<CapsuleCollider>();
        DisableTriggerBox();
        DisableTriggerCapsule();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Attempt to get the CapsuleCollider from the collided object
    CapsuleCollider otherCapsuleCollider = other.GetComponent<CapsuleCollider>();
    
     
        Health health = other.GetComponentInParent<Health>();
        if (health != null)
        {
            health.Damage(damage);
        }
    
    }

    public void EnableTriggerBox()
    {
        triggerBox.enabled = true;
         Debug.Log(" triggerBox enabled");
    }

    public void DisableTriggerBox()
    {
        triggerBox.enabled = false;
        Debug.Log(" triggerBox disabled");
    }
    public void EnableTriggerCapsule()
    {
        capsuleCollider.enabled = true;
         Debug.Log(" TriggerCapsule enabled");
    }

    public void DisableTriggerCapsule()
    {
        capsuleCollider.enabled = false;
        Debug.Log(" TriggerCapsule disabled");
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
