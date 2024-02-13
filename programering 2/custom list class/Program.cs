namespace custom_list_class
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var LinkedList = new LList<string>("hej");
            var a = LinkedList.AddAfter(LinkedList.First,"hejdå");
            var b = LinkedList.AddAfter(a, "sfdgh");
            var c = LinkedList.AddAfter(b, "huyylk");
            var b2 = LinkedList.AddAfter(b, "b2");

            var loopnode = LinkedList.First;
            while (loopnode != null)
            {
                Console.WriteLine(loopnode.Data.ToString());
                loopnode = loopnode.Next;
            }

            LinkedList.clear();

            var a2 = LinkedList.AddAfter(LinkedList.First, "1");
            var b3 = LinkedList.AddAfter(a2, "2");
            var c2 = LinkedList.AddAfter(b3, "3");
            var b4 = LinkedList.AddAfter(b3, "4");

            var loopnode2 = LinkedList.First;
            while (loopnode2 != null)
            {
                Console.WriteLine(loopnode2.Data.ToString());
                loopnode2 = loopnode2.Next;
            }

            var mylist = new CustomList<string>();
            string command;
            bool quitnow = false;
            mylist.Add("a");
            mylist.Add("b");
            mylist.Add("c");
            mylist.Add("d");
            mylist.Add("e");
            mylist.Add("f");
            mylist.Add("g");
            mylist.Add("h");
            while (!quitnow) 
            {
                command = Console.ReadLine();
                command = command.ToLower();
                switch (command)
                {
                    case "add":
                        try
                        {
                            mylist.Add(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("leo fix your code");
                        }
                        break;
                    case "removeat":
                        try
                        {
                            mylist.RemoveAt(int.Parse(Console.ReadLine()));
                        }
                        catch
                        {
                            Console.WriteLine("leo fix your code");
                        }
                        break;
                    case "remove":
                        try
                        {
                            mylist.Remove(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("leo fix your code");
                        }
                        break;
                    case "getdata":
                        string IndexToGet = Console.ReadLine();
                        string DataFromList = "something broke";
                        try
                        {
                            DataFromList = mylist.GetData(int.Parse(IndexToGet));
                        }
                        catch { Console.WriteLine("can only accept ints"); }
                        Console.WriteLine(DataFromList);
                        break;
                    case "getcount":
                        Console.WriteLine(mylist.GetCount().ToString());
                        break;
                    case "getcapacity":
                        Console.WriteLine(mylist.GetCapacity().ToString());
                        break;
                    case "getalldata":
                        int ListCount = mylist.GetCount();
                        string[] temp = new string[ListCount];
                        Array.Copy(mylist.GetAllData(), temp, ListCount);
                        for (int i = 0; i < temp.Length;i++)
                        {
                            Console.WriteLine(temp[i]);
                        }
                        break;
                    case "setcapacitymultiplier":
                        try
                        {
                            mylist.SetCapacityMultiplier(int.Parse(Console.ReadLine()));
                        }
                        catch
                        {
                            Console.WriteLine("can only accept ints");
                        }
                        break;
                    case "swap":
                        uint IndexA = uint.MaxValue;
                        uint IndexB = uint.MaxValue;
                        try
                        {
                            IndexA = uint.Parse(Console.ReadLine());
                            IndexB = uint.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("only accepts ints 0 and above");
                        }
                        mylist.swap(IndexA, IndexB);
                        break;
                    case "find":
                        string findthis = Console.ReadLine();
                        try
                        {
                            mylist.find(findthis);
                        }
                        catch { }
                        break;
                    case "close":
                        quitnow = true;
                        break;
                }
            }
        }
    }
}
