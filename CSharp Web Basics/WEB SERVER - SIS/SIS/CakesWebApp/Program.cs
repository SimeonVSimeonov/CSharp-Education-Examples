﻿using CakesWebApp.Controllers;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;

namespace CakesWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] =
                request => new HomeController().Index(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/login"] =
                request => new AccountController().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/register"] =
                request => new AccountController().Register(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/register"] =
                request => new AccountController().DoRegister(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/login"] =
                request => new AccountController().DoLogin(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/hello"] =
                request => new HomeController().Hello(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/logout"] =
                request => new AccountController().Logout(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/profile"] =
                request => new AccountController().MyProfile(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/addcake"] =
                request => new CakeController().AddCakeView(request);

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
