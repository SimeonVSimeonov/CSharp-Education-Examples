namespace _05BarracksFactory.Core.Commands
{
    using _05BarracksFactory.Contracts;
    using System;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            try
            {
                this.Repository.RemoveUnit(this.Data[1]);
                return $"{this.Data[1]} retired!";
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
        }
    }
}
