using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendStateMachineBehaviour : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var defend = animator.GetComponent<Defend>();
        if (defend != null)
        {
            defend.DisableTriggerCapsule();
        }
    }
}
