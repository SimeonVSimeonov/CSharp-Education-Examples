namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer,
            IFestivalController festivalCоntroller,
            ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string result;

                try
                {
                    result = this.ProcessCommand(input);
                }
                catch (Exception ex) 
                {
                    if (ex.InnerException != null)
                    {
                        result = "ERROR: " + ex.InnerException.Message;
                    }
                    else
                    {
                        result = "ERROR: " + ex.Message;
                    }
                }
                this.writer.WriteLine(result.Trim());
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split();

            var command = tokens[0];

            string result;
            if (command == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
            }
            else
            {
                string[] commandParams = tokens
                    .Skip(1)
                    .ToArray();

                var festivalcontrolfunction = this.festivalCоntroller.GetType()
               .GetMethods()
               .FirstOrDefault(x => x.Name == command);

                result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { commandParams });
            }

            return result;
        }
    }
}