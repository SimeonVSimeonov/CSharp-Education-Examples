using SoftUniRestaurant.Core;
using SoftUniRestaurant.IO;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            ;
            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
