using System;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Factories
{
    public class StorageFactory
    {
        public Storage.Storage CreateStorage(string name, string name2)
        {
            Storage.Storage product;
            switch (name)
            {
                case "AutomatedWarehouse":
                    product = new AutomatedWarehouse(name2);
                    break;
                case "DistributionCenter":
                    product = new DistributionCenter(name2);
                    break;
                case "Warehouse":
                    product = new Warehouse(name2);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid storage type!");
            }

            return product;
        }
    }
}