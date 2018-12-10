using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected IList<IAnimal> procedureHistory;

        public Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        internal void CheckTime(int time, IAnimal animal)
        {
            if (time <= animal.ProcedureTime)
            {
                animal.ProcedureTime -= time;
            }
            else
            {
                throw new AggregateException("Animal doesn't have enough procedure time");
            }
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            string[] animalsInfo = procedureHistory
                .OrderBy(a => a.Name)
                .Select(a => a.ToString())
                .ToArray();
            sb.AppendLine(string.Join(Environment.NewLine, animalsInfo));

            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
