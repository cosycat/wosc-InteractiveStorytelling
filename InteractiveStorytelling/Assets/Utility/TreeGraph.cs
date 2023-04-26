using System.Collections.Generic;

namespace Utility {
    public class TreeGraph<T> where T : TreeGraph<T>.INode{
        
        public T Root { get; set; }
        
        public interface INode {
        
            public INode Parent { get; protected set; }
            public List<INode> Children { get; }

        }
        
    }
    
    
}