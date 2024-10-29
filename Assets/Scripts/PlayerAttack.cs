using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;
    private Animator animator;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
         // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
        // Ensure the attack area is the correct child object with a Collider attached
        /*attackArea = transform.GetChild(0).gameObject;
        
        // Ensure the attack area has a Collider set as Trigger
        Collider attackCollider = attackArea.GetComponent<Collider>();
        if (attackCollider != null)
        {
            attackCollider.isTrigger = true;
        }

        // Set the attack area initially inactive
        attackArea.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        // Listen for attack input (space key in this example, you can change it)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        // Handle attack duration timer
        /*
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                // Reset the timer and stop attacking
                timer = 0f;
                attacking = false;
                attackArea.SetActive(false);
            }
        }*/
    }

    private void Attack()
    {
        attacking = true;
        //attackArea.SetActive(true);
        // Set the "attacking" trigger in the Animator
        animator.SetTrigger("attacking");
    }

}
