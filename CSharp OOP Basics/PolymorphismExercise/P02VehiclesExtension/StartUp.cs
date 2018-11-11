using P02VehiclesExtension.Core;

namespace P02VehiclesExtension
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
