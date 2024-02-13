using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_list_class
{
    public class LLNode<T>
    {
        public LLNode(T _Data, LLNode<T> _Next = null, LLNode<T> _previous = null)
        {
            Data = _Data;
            Next = _Next;
            previous = _previous;
        }
        public T Data;
        public LLNode<T> Next;
        public LLNode<T> previous;

    }
    
}
