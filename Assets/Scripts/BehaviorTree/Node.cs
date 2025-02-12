using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Pathfinding.BehaviourTrees {
    public class Leaf : Node {
        readonly IStrategy strategy;

        public Leaf(string name, IStrategy strategy, int priority = 0) : base(name, priority) {
            // Preconditions.CheckNotNull(strategy);
            this.strategy = strategy;
        }
        
        public override Status Process() => strategy.Process();

        public override void Reset() => strategy.Reset();
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
