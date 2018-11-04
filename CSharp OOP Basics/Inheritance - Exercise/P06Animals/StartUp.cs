using System;
using P06Animals.Animals;
using P06Animals.Core;

namespace P06Animals
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
