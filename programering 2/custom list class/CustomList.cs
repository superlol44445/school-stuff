namespace custom_list_class
{

    internal class CustomList<T>
    {
        private int Count;
        private int Capacity;
        private int CM_CapacityMultiplier;
        private int TCM_TimesCapacityMultiplied;
        private T[] data;
        private T[] temp;
        public CustomList()
        {
            Capacity = 8;
            data = new T[Capacity];
            Count = 0;
            TCM_TimesCapacityMultiplied = 1;
            CM_CapacityMultiplier = 32;
        }
        public void Add(T item)
        {
            int OldCount = Count;
            int Old_TCM_TimesCapacityMultiplied = TCM_TimesCapacityMultiplied;
            Count++;
            double myDouble = (double)Count / CM_CapacityMultiplier;
            TCM_TimesCapacityMultiplied = (int)Math.Ceiling(myDouble);
            if(Old_TCM_TimesCapacityMultiplied != TCM_TimesCapacityMultiplied)
            {
                Capacity = CM_CapacityMultiplier * TCM_TimesCapacityMultiplied;
                temp = new T[Count];
                Array.Copy(data, temp, OldCount);
                data = new T[Capacity];
                Array.Copy(temp, data, Count);
                
            }
            data[OldCount] = item;
        }
        public void RemoveAt(int IndexToRemove)
        {
            int OldCount = Count;
            int IndexToCopyToo = 0;
            Count--;
            T[] temp = new T[Count];
            for (int i = 0; i < OldCount; i++)
            {
                if (i!=IndexToRemove)
                {
                    temp[IndexToCopyToo] = data[i];
                    IndexToCopyToo++;
                }

            }
            double myDouble = (double)Count / CM_CapacityMultiplier;
            TCM_TimesCapacityMultiplied = (int)Math.Ceiling(myDouble);
            Capacity = CM_CapacityMultiplier * TCM_TimesCapacityMultiplied;
            data = new T[Capacity];
            Array.Copy(temp, data, Count);
        }
        public void Remove(T RemoveThis)
        {
            int OldCount = Count;
            int IndexToCopyToo = 0;
            Count--;
            T[] temp = new T[Count];
            for (int i = 0; i < OldCount; i++)
            {
                if (data[i].GetHashCode() != RemoveThis.GetHashCode())
                {
                    temp[IndexToCopyToo] = data[i];
                    IndexToCopyToo++;
                }

            }
            double myDouble = (double)Count / CM_CapacityMultiplier;
            TCM_TimesCapacityMultiplied = (int)Math.Ceiling(myDouble);
            Capacity = CM_CapacityMultiplier * TCM_TimesCapacityMultiplied;
            data = new T[Capacity];
            Array.Copy(temp, data, Count);
        }
        public T GetData(int index)
        {
            if (index < Count)
            {
                return data[index];
            }
            else
            {
                return default;
            }
        }
        public T[] GetAllData()
        {
            T[] temp = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                temp[i] = data[i];
            }
            return temp;
        }
        public void SetCapacityMultiplier(int NewMultiplier)
        {
            CM_CapacityMultiplier = NewMultiplier;
        }
        public void swap(uint IndexA,uint IndexB)
        {
            T temp;
            try
            {
                if(IndexA < Count && IndexB < Count)
                {
                    temp = data[IndexA];
                    data[IndexA] = data[IndexB];
                    data[IndexB] = temp;
                    Console.WriteLine("The items at IndexA and IndexB were swapped");
                }
            }
            catch 
            {
                Console.WriteLine("The items at IndexA and IndexB weren't swapped");
            }
        }
        public void find(string v)
        {
            for (int i = 0;i < Count; i++)
            {
                try
                {
                    if (data[i].GetHashCode() == v.GetHashCode())
                    {
                        Console.WriteLine(v," was found at ",i.ToString());
                    }
                }
                catch
                { }
            }
            Console.WriteLine("couldn't find it in the list");
        }

        public int GetCapacityMultiplier() {  return CM_CapacityMultiplier; }
        public int GetCount() { return Count; }
        public int GetCapacity() { return Capacity; }
    }
}
