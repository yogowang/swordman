using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayerDetector", story: "Check if [detector] has a [target]", category: "Action", id: "72fb77371b7de9d9bdfba1a2bc0edeff")]
public partial class PlayerDetectorAction : Action
{
    [SerializeReference] public BlackboardVariable<TargetDetector> Detector;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    protected override Status OnStart()
    {
        if(Detector.Value.ifWithinDetectDistance()){
            Target.Value=Detector.Value.player;
            //Target.Value=GameObject.FindWithTag("Player");
            if (Target.Value==null)
            Debug.Log($"player is null");
            return Status.Success;
        }
            return Status.Failure;
        }
        protected override Status OnUpdate()
    {
        if(Detector.Value.ifWithinDetectDistance()){
            Target.Value=Detector.Value.player;
            //Target.Value=GameObject.FindWithTag("Player");
            if (Target.Value==null)
            Debug.Log($"player is null");
            return Status.Success;
        }
            return Status.Failure;
        }
    
}

