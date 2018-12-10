using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure, IProcedure
    {
        private const int RenoveEnergy = 8;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Energy -= RenoveEnergy;
            animal.IsVaccinated = true;
            base.procedureHistory.Add(animal);
        }
    }
}
