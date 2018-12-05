namespace P07InfernoInfinity
{
    using P07InfernoInfinity.Contracts;
    using P07InfernoInfinity.Core;
    using P07InfernoInfinity.Core.Factories;
    using P07InfernoInfinity.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var repository = new WeaponRepository();
            var interpreter = new CommandInterpreter();
            var weaponFactory = new WeaponFactory();
            var gemFactory = new GemFactory();

            IRunnable engine = new Engine(gemFactory, weaponFactory, interpreter, repository);

            engine.Run();
        }
    }
}
