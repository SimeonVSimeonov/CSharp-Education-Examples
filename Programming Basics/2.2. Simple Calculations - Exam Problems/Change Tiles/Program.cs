using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Change_Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            int plazaLong = int.Parse(Console.ReadLine());
            double tilesW = double.Parse(Console.ReadLine());
            double tilesL = double.Parse(Console.ReadLine());
            int benchW = int.Parse(Console.ReadLine());
            int benchL = int.Parse(Console.ReadLine());

            var area = plazaLong * plazaLong;
            var bench = benchL * benchW;
            var tiles = tilesL * tilesW;
            var areaCov = area - bench;
            var allTiles = areaCov / tiles;
            var workTime = allTiles * 0.2;
            Console.WriteLine(allTiles);
            Console.WriteLine(workTime);

        }
    }
}
