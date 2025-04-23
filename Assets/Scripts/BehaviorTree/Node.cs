using System.Collections.Generic;
using System.Collections;
namespace BehaviorTree
{
    public enum NodeState{
        RUNNING,
        SUCCESS,
        FAILURE
    }
    private Dictionary<string,object> _dataContext = new Dictionary<string, object>();
    public class Node{
        protected Node parent;
        protected List<Node> children;
        public Node()
        {
            parent=null;
        }
        public Node(List<Node> children){
            foreach (Node child in children)
            {
                _Attach(child);
            }
        }
        private void _Attach(Node node){
            node.parent=this;
            children.add(node);
        }
        public  virtual NodeState Evaluate()=> NodeState.FAILURE;
        public void SetData(string key,object value){
            _dataContext[key] =value;
        }
        public object GetData(string key){
            object value =null;
            
        }
    }
}