namespace P07InfernoInfinity.Core.Commands
{
    using P07InfernoInfinity.Contracts;
    using System;

    public class PrintCommand : Command
    {
        private IRepository repository;

        public PrintCommand(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            string result = this.repository.PrintWeapon(this.Data[0]);

            Console.WriteLine(result);
        }
    }
}
