using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure, IProcedure
    {
        private const int AddHappiness = 12;
        private const int AddEnergy = 10;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness += AddHappiness;
            animal.Energy += AddEnergy;
            base.procedureHistory.Add(animal);
        }
    }
}
