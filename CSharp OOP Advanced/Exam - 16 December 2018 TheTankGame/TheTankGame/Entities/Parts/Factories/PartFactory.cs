using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;

namespace TheTankGame.Entities.Parts.Factories.Contracts
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(p => p.Name == partType + "Part");
            ;
            IPart part = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);

            return part;
        }
    }
}
