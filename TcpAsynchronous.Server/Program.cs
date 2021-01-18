namespace TcpAsynchronous.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start a new Socket Server
            AsynchronousSocketListener.StartListening();
        }
    }
}