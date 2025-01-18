using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : MonoBehaviour
{
    public DefendSO preDefend;
    private Animator animator;  // Animator component to control animations
    private bool isDefend;
    private float holdingTime;
    private  Weapon weapon;
    private
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component attached to this GameObject
        weapon= GetComponentInChildren<Weapon>();
        holdingTime=0.0f;
        isDefend=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))  // Check if the right mouse button is pressed down
        {
            if(isDefend==false){
                holdingTime=Time.time;
                EnableTriggerCapsule();
            }
            DefendAction();
        }
        else{
        EndDefend();
        }
    }
    private void DefendAction(){
    
            isDefend=true;
    animator.runtimeAnimatorController=preDefend.animatorOV;
    float ratio=(Time.time-holdingTime)/animator.GetCurrentAnimatorClipInfo(0).Length;
    animator.Play("Defend",0, ratio<1.0f? ratio :1.0f);
    
    }
    private void FreezeDefend(){
        animator.Play("Defend",0,0.9f*animator.GetCurrentAnimatorClipInfo(0).Length);
    }
    private void EndDefend(){
        DisableTriggerCapsule();
       isDefend=false;
       holdingTime=0.0f;
    }
     public void EnableTriggerCapsule()
    {
          weapon.EnableTriggerCapsule();         
    }

    public void DisableTriggerCapsule()
    {
        weapon.DisableTriggerCapsule();
        
    }
}
