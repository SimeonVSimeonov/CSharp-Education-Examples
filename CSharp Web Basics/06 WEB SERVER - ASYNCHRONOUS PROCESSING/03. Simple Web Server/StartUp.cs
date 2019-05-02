using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _03._Simple_Web_Server
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");
            int port = 1300;
            TcpListener tcpListener = new TcpListener(address, port);
            tcpListener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at 127.0.0.1:{port}");

            var task = Task.Run(() => ConnectWithTcpClient(tcpListener));
            task.Wait();
        }

        public static async Task ConnectWithTcpClient(TcpListener tcpListener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client.....");
                var client = await tcpListener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected.");

                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, buffer.Length);
                Console.WriteLine("============================");

                byte[] data = Encoding.ASCII.GetBytes("Hello from server!");
                client.GetStream().Write(data, 0, data.Length);

                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }
        }
    }
}
