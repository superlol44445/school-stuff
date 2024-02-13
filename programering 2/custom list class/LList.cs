using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace custom_list_class
{

    internal class LList<T>
    {
        public LLNode<T> First;
        public LLNode<T> Last;
        public LList(T Data)
        {
            this.First = new LLNode<T>(Data);
            this.Last = new LLNode<T>(Data);
        }
        // After is the node that will link to this new one
        public LLNode<T> AddAfter(LLNode<T> After, T Data)
        {
            if(this.First == null)
            {
                isEmpty(Data);
                return First;
            }
            LLNode<T> NewNode = new LLNode<T>(Data);
            NewNode.Next = After.Next;
            NewNode.previous = After;
            After.Next = NewNode;
            this.Last = NewNode;
            return NewNode;
        }
        public void removefirst()
        {
                this.First = this.First.Next;
        }
        public void removelast() 
        {
            Last = this.Last.Next;
        }
        public void remove(T item)
        {
            if (First.GetType() == item.GetType())
            {
                Console.WriteLine("cant remove that from the list their not the same datatype");
                return;
            }
            var loopnode = this.First;
            while( loopnode.Next.GetHashCode() != item.GetHashCode())
            {
                loopnode = loopnode.Next;
            }
            if (loopnode.Next.Next != null)
            {
                loopnode.Next = loopnode.Next.Next;
                return;
            }
            else
            {
                loopnode.Next = null;
            }
        }
        private void isEmpty(T Data)
        {
            LLNode<T> NewNode = new LLNode<T>(Data);
            First = NewNode;
            return;
        }
        public T[] GetDataAsArray ()
        {
            var loopnode = First;
            List<T> data = new List<T>();
            do
            {
                data.Add(loopnode.Data);
                loopnode = loopnode.Next;
            }
            while (loopnode != null);
            return data.ToArray();
        }
        public void clear()
        {
            this.First = null;
        }
    }
}