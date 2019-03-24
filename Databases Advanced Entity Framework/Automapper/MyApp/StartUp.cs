using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core;
using MyApp.Core.Contracts;
using MyApp.Data;
using System;

namespace MyApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider services = ConfigureServices();
            IEngine engine = new Engine(services);
            engine.Run();
            //1.Database
            //2.Command pattern
            //3.DI
            //4.DTOs
            //5.Service Layer
            
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MyAppContext>(db =>
                db.UseSqlServer("Server=DESKTOP-KDM5RU8\\SQLEXPRESS;Database=MySpecialApp;Integrated Security=True;"));

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<Mapper>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }

    }
}
