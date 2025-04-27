using System.Collections.Generic;
using System.Collections;
namespace BehaviorTree
{
        public class Node{
        public enum NodeState{
        RUNNING,
        SUCCESS,
        FAILURE
    }
        private Dictionary<string,object> _dataContext = new Dictionary<string, object>();

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
            children.Add(node);
        }
        public  virtual NodeState Evaluate()=> NodeState.FAILURE;
        public void SetData(string key,object value){
            _dataContext[key] =value;
        }
        public object GetData(string key){
            object val = null;
	        if (_dataContext.TryGetValue(key, out val))
	            return val;
	
	        Node node = parent;
	        if (node != null)
	            val = node.GetData(key);
	        return val;
            
        }
        public bool ClearData(string key){
            object val = null;
	        if (_dataContext.TryGetValue(key, out val)){
                _dataContext.Remove(key);
                 return true;
            }
	           
	
	        Node node = parent;
	        while(node != null){
                bool cleared=node.ClearData(key);
                if(cleared)
                return true;
                node=node.parent;
            }
	            
	        return false;
            
        }
    }
}