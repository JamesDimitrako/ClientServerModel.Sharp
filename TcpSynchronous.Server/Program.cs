namespace TcpSynchronous.Server
{
    class Program
    {
        static int Main(string[] args)
        {
            SynchronousSocketListener.StartListening();  
            return 0;  
        }
    }
}