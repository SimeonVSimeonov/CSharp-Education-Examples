namespace P07InfernoInfinity.Core.Factories
{
    using P07InfernoInfinity.Contracts;
    using P07InfernoInfinity.Models.Enums;
    using System;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string clarity, string gemType)
        {
            GemClarity gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), clarity);

            Type classType = Type.GetType(gemType);

            IGem instance = (IGem)Activator.CreateInstance(classType, new object[] { gemClarity });

            return instance;
        }
    }
}
