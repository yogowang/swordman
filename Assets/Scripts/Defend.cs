using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    public DefendSO preDefend;
    public DefendSO Defending;
        private Animator animator;  // Animator component to control animations

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component attached to this GameObject
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))  // Check if the right mouse button is pressed down
        {
            // Start the "predefend" animation
           
            
                animator.runtimeAnimatorController = preDefend.animatorOV;  // Set the animator override controller
                animator.Play("Defend", 0, 0);  // Play the predefend animation
                animator.runtimeAnimatorController = Defending.animatorOV; 
                animator.Play("Defend", 0, 0);
            
        }
        
    }
}
