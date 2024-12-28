using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   private int damage;
    BoxCollider triggerBox;

    private void Start()
    {
        triggerBox = GetComponent<BoxCollider>();
        DisableTriggerBox();
    }

    private void OnTriggerEnter(Collider other)
    {
        Health health= other.GetComponentInParent<Health>();
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
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
