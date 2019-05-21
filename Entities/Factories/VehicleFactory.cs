using System;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string name)
        {
            Vehicle product;
            switch (name)
            {
                case "Semi":
                    product = new Semi();
                    break;
                case "Truck":
                    product = new Truck();
                    break;
                case "Van":
                    product = new Van();
                    break;

                default:
                    throw new InvalidOperationException($"Invalid vehicle type!");
            }

            return product;
        }
    }
}