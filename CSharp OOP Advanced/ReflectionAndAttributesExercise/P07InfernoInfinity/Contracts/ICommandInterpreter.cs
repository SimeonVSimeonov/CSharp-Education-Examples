namespace P07InfernoInfinity.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] data);
    }
}
