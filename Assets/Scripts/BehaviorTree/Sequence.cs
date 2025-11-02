using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using System.Collections.Generic;
namespace BehaviorTree
{
    // Sequence node that executes its
public class Sequence : Node
{
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
        {
            foreach (Node child in children)
            {
                NodeState childState = child.Evaluate();
                if (childState == NodeState.FAILURE)
                {
                    state = NodeState.FAILURE;
                    return state;
                }
                if (childState == NodeState.RUNNING)
                {
                    state = NodeState.RUNNING;
                    return state;
                }
            }
            state = NodeState.SUCCESS;
            return state;
        }
}
}
