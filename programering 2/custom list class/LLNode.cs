using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_list_class
{
    public class LLNode<T>
    {
        public LLNode(T _Data, LLNode<T> _Next = null, LLNode<T> _Previous = null)
        {
            Data = _Data;
            Next = _Next;
            Previous = _Previous;
        }
        public T Data;
        public LLNode<T> Next;
        public LLNode<T> Previous;

    }
    
}
