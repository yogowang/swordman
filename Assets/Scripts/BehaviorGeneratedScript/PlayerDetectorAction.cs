using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayerDetector", story: "Check if [detector] has a target", category: "Action", id: "72fb77371b7de9d9bdfba1a2bc0edeff")]
public partial class PlayerDetectorAction : Action
{
    [SerializeReference] public BlackboardVariable<TargetDetector> Detector;

    protected override Status OnStart()
    {
        return Detector.Value.ifWithinDetectDistance()==null? Status.Failure:Status.Success;
    }

    
}

