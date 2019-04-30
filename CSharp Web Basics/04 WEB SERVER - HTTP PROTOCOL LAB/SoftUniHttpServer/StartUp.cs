using System;

namespace SoftUniHttpServer
{
    public class StartUp
    {
        public static void Main()
        {
            IHttpServer httpServer = new HttpServer();

            httpServer.Start();
        }
    }
}
