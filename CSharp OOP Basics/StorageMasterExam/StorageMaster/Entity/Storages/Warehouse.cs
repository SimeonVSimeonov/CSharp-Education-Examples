using StorageMaster.Entity.Vehicles;

namespace StorageMaster.Entity.Storages
{
    public class Warehouse : Storage
    {
        private const int WarehouseCapacity = 10;
        private const int WarehouseGarageSlots = 10;
        private static Vehicle[] DefaultVehicles = {
            new Semi(),
            new Semi(),
            new Semi()
        };

        public Warehouse(string name)
            : base(name, WarehouseCapacity, WarehouseGarageSlots, DefaultVehicles)
        {
        }
    }
}
