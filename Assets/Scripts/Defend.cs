using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    public DefendSO preDefend;
    public DefendSO Defending;
    private Animator animator;  // Animator component to control animations
    private bool isDefend;
    private float holdingTime;
    private
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component attached to this GameObject
        holdingTime=0.0f;
        isDefend=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))  // Check if the right mouse button is pressed down
        {
            DefendAction();
        }
        else{
        EndDefend();
        }
    }
    private void DefendAction(){
    if(isDefend==false){
            isDefend=true;
    animator.runtimeAnimatorController=preDefend.animatorOV;
    animator.Play("Defend");
    }
    if(isDefend==true && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f){ 
    animator.runtimeAnimatorController=Defending.animatorOV;
    animator.Play("Defend");
    }
        
    }
    private void FreezeDefend(){
        animator.Play("Defend",0,0.9f*animator.GetCurrentAnimatorClipInfo(0).Length);
    }
    private void EndDefend(){
       isDefend=false;
    }
    
}
