namespace StorageMaster
{
    using StorageMaster.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new StorageMaster());
            engine.Run();
        }
    }
}
