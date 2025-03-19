using System;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

namespace Pathfinding.BehaviourTrees {
    public interface IStrategy {
        Node.Status Process();

        void Reset() {
            // Noop
        }
    }

    
}
