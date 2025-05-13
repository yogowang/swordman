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
            bool isAnyChildRunning = false;
            foreach (Node child in children)
            {
                
                NodeState childState = child.Evaluate();
                if (childState == NodeState.RUNNING)
                {
                    isAnyChildRunning = true;
                    state = NodeState.RUNNING;
                    return state;
                }
                else if (childState == NodeState.SUCCESS)
                {
                    state = NodeState.SUCCESS;
                    return state;
                }
                else if (childState == NodeState.FAILURE)
                {
                    continue;
                
                }
                else{
                    continue;
                }
            }
            state = isAnyChildRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
}
}
