using System;
using System.Collections.Generic;

namespace _01._Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            var greenlight = int.Parse(Console.ReadLine());
            var freewindow = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();

            var carQueue = new Queue<string>();
            int passedCars = 0;

            while (input != "END")
            {
                if (input != "green")
                {

                    carQueue.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int currentGreenLight = greenlight;

                string currentCar = string.Empty;
                string outputCar = string.Empty;

                while (carQueue.Count > 0 && currentGreenLight > 0)
                {
                    currentCar = carQueue.Dequeue();
                    outputCar = currentCar;
                    currentGreenLight -= currentCar.Length;

                    if (currentGreenLight >= 0)
                    {
                        passedCars++;
                        continue;
                    }

                    currentCar = currentCar.Remove(0, currentCar.Length - currentGreenLight * -1);
                    currentGreenLight += freewindow;

                    if (currentGreenLight >= 0)
                    {
                        passedCars++;
                        break;
                    }

                    currentCar = currentCar.Remove(0, currentCar.Length - currentGreenLight * -1);
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{outputCar} was hit at {currentCar[0]}.");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
