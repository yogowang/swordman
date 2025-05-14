using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using System.Collections.Generic;
namespace BehaviorTree
{

public class Selector : Node
{
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
        {
            foreach (Node child in children)
            {
                
                NodeState childState = child.Evaluate();
                if (childState == NodeState.RUNNING)
                {
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
            state = NodeState.FAILURE;
            return state;
        }
}
}