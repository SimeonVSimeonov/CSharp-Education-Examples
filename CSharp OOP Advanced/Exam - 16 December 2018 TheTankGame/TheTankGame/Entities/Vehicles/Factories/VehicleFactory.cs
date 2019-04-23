namespace TheTankGame.Entities.Vehicles.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Vehicles.Contracts;
    using TheTankGame.Entities.Vehicles.Factories.Contracts;

    public class VehicleFactory : IVehicleFactory
    {

        IAssembler assembler = new VehicleAssembler();

        public IVehicle CreateVehicle(string vehicleType, string model, double weight,
            decimal price, int attack, int defense, int hitPoints)
        {
            
            Type type = Assembly.GetCallingAssembly()
                 .GetTypes()
                 .FirstOrDefault(t => t.Name == vehicleType);
          
            IVehicle vehicle = (IVehicle)Activator.CreateInstance(type, model, weight, price,
                attack, defense, hitPoints, assembler);

            return vehicle;
        }
    }
}
