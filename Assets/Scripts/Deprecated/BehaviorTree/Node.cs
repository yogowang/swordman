using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Pathfinding.BehaviourTrees {
    public interface IPolicy {
        bool ShouldReturn(Node.Status status);
    }
    public static class Policies {
        public static readonly IPolicy RunForever = new RunForeverPolicy();
        public static readonly IPolicy RunUntilSuccess = new RunUntilSuccessPolicy();
        public static readonly IPolicy RunUntilFailure = new RunUntilFailurePolicy();
        
        class RunForeverPolicy : IPolicy {
            public bool ShouldReturn(Node.Status status) => false;
        }
        
        class RunUntilSuccessPolicy : IPolicy {
            public bool ShouldReturn(Node.Status status) => status == Node.Status.Success;
        }
        
        class RunUntilFailurePolicy : IPolicy {
            public bool ShouldReturn(Node.Status status) => status == Node.Status.Failure;
        }
    }
    
    public class Leaf : Node {
        readonly IStrategy strategy;

        public Leaf(string name, IStrategy strategy, int priority = 0) : base(name, priority) {
            // Preconditions.CheckNotNull(strategy);
            this.strategy = strategy;
        }
        
        public override Status Process() => strategy.Process();

        public override void Reset() => strategy.Reset();
    }
     public class BehaviourTree : Node {
        readonly IPolicy policy;
        
        public BehaviourTree(string name, IPolicy policy = null) : base(name) {
            this.policy = policy ?? Policies.RunForever;
        }

        public override Status Process() {
            Status status = children[currentChild].Process();
            if (policy.ShouldReturn(status)) {
                return status;
            }
            
            currentChild = (currentChild + 1) % children.Count;
            return Status.Running;
        }

        public void PrintTree() {
            StringBuilder sb = new StringBuilder();
            PrintNode(this, 0, sb);
            Debug.Log(sb.ToString());
        }

        static void PrintNode(Node node, int indentLevel, StringBuilder sb) {
            sb.Append(' ', indentLevel * 2).AppendLine(node.name);
            foreach (Node child in node.children) {
                PrintNode(child, indentLevel + 1, sb);
            }
        }
    }
   public class Node {
        public enum Status { Success, Failure, Running }
        
        public readonly string name;
        public readonly int priority;
        
        public readonly List<Node> children = new();
        protected int currentChild;
        
        public Node(string name = "Node", int priority = 0) {
            this.name = name;
            this.priority = priority;
        }
        
        public void AddChild(Node child) => children.Add(child);
        
        public virtual Status Process() => children[currentChild].Process();

        public virtual void Reset() {
            currentChild = 0;
            foreach (var child in children) {
                child.Reset();
            }
        }
    }
}
