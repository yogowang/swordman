using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "PlayerDetector", story: "Check if [detector] has a [target]", category: "Conditions", id: "34cb0d8ecdd9440cc486a9f3f7763ad3")]
public partial class PlayerDetectorCondition : Condition
{
    [SerializeReference] public BlackboardVariable<TargetDetector> Detector;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    public override bool IsTrue()
    {
        if (Target.Value!=null)
        return true;
        else
        return false;
    }

    public override void OnStart()
    {
        if(Detector.Value.ifWithinDetectDistance()){
            //Target.Value=GameObject.FindWithTag("Player");
            Target.Value=Detector.Value.player;
             if (Target.Value==null)
            Debug.Log($"player is null");
           
        }
        else
        Target.Value=null;
           
    }
    public override void OnEnd()
    {
    }
}
