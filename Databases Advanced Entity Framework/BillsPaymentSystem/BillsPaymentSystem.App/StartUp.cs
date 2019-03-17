﻿using BillsPaymentSystem.App.Core;
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using System;

namespace BillsPaymentSystem.App
{
    public class StartUp
    {
        public static void Main()
        {
            //using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            //{
            //    DbInitializer.Seed(context);
            //}
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
