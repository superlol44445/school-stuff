using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace custom_list_class
{

    internal class LList<T>
    {
        public LLNode<T> First;
        public LLNode<T> Last;
        private int Count;
        
        public LList()
        {
        }
        public T this[int i]
        {
            //get and set functions with IndexOutOfRangeException and InvalidOperationException if the list is empty
            get
            {
                if (i >= Count || i < 0)
                {
                    throw new IndexOutOfRangeException("Index is out of valid range.");
                }
                if(Count == 0)
                {
                    throw new InvalidOperationException("cant get variable at i. list is empty");
                }
                var loopnode = First;
                for(int j = 0; j < i; j++) { loopnode = loopnode.Next; }
                return loopnode.Data; 
            }
            set
            {
                if (i >= Count || i < 0)
                {
                    throw new IndexOutOfRangeException("the index you are trying to change is out of valid range.");
                }
                if (Count == 0)
                {
                    throw new InvalidOperationException("cant get variable at i. list is empty");
                }
                var loopnode = First;
                for (int j = 0; j < i; j++) { loopnode = loopnode.Next; }
                loopnode.Data = value;
                return;
            }
        }
        // After is the node that will link to this new one
        public LLNode<T> AddAfter(LLNode<T> After, T Data)
        {
            // if list empty: set both First and Last to the new node using mehtod Isempty 
            if (this.First == null)
            {
                IsEmpty(Data);
                return this.First;
            }
            // Non-empty list: add the new node after the a node chossen by the programer instead of after the last on in the list
            LLNode<T> NewNode = new LLNode<T>(Data);
            NewNode.Next = After.Next;
            NewNode.Previous = After;
            After.Next = NewNode;
            this.Last = NewNode;
            Count++;
            return NewNode;
        }
        public void Add( T Data)
        {
            // if list empty: set both First and Last to the new node using mehtod Isempty 
            if (this.First == null)
            {
                IsEmpty(Data);
                return;
            }
            // Non-empty list: add the new node after Last
            LLNode<T> NewNode = new LLNode<T>(Data);
            Last.Next = NewNode;
            NewNode.Previous = Last;
            Last = NewNode;
        }
        //removes the first node in the list
        public void removefirst()
        {
            CheckIfEmpty();
            this.First = this.First.Next;
            this.First.Previous = null;
            Count--;
        }
        //removes the last node in the list
        public void removelast() 
        {
            CheckIfEmpty();
            if (First == Last)
            {
                First = null;
                Last = null;
            }
            Last = Last.Previous;
            Last.Next = null;
            Count--;
        }
        //tries to remove a specific item from the list
        public void remove(T item)
        {
            CheckIfEmpty();
            var loopnode = this.First;
            //goes through the entire list until it find the specific item and if it cant find it it return nothing
            while(!loopnode.Data.Equals(item) )
            {
                loopnode = loopnode.Next;
            }
            if (loopnode == null)
            {
                Console.WriteLine("couldn't find item in list");
                return;
            }

            //if it finds the item it removs it from the list and reconnects the nearby nodes
            var next = loopnode.Next;
            var previous = loopnode.Previous;
            if (next != null)
            {
                previous.Next = next;
            }
            if (previous != null)
            {
                next.Previous = previous;
            }
            Count--;
        }
        //checks if list is empty and
        private void CheckIfEmpty()
        {
            if (First == null)
            {
                Console.WriteLine("list is already empty");
                return;
            }
        }
        //if the list is empty this method creates a new first node and also assigns it as the last node since its the only one
        private void IsEmpty(T Data)
        {
            LLNode<T> NewNode = new LLNode<T>(Data);
            First = NewNode;
            Last = NewNode;
            return;
        }
        //returns the data in every single node as an array
        public T[] GetDataAsArray (bool StartAtLast = false)
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
        //clears the entire list
        public void clear()
        {
            this.First = null;
            this.Last = null;
        }
    }
}