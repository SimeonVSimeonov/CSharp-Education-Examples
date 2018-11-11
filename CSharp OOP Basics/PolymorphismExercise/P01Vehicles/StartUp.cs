using P01Vehicles.Core;

namespace P01Vehicles
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
