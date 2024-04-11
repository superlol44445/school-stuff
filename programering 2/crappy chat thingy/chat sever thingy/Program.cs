namespace message_sender_thingy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Server(1234).run();
        }
    }
}
