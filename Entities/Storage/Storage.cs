using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storage
{
    using Products;
    using Vehicles;

    public class Storage
    {
        private readonly List<Vehicle> Garage;
        private readonly List<Product> Products;
        private readonly List<Storage> storage;
        //    private IEnumerable<Vehicle> e_vehicles;

        protected Storage(string name, int capacity, int garageSlots, bool isFull/*, IEnumerable<Vehicle> e_vehicles*/)
        {
            this.SName = name;
            this.SCapacity = capacity;
            this.SGarageSlots = garageSlots;
            this.SIsFull = isFull;
        //    this.Vehicles = e_vehicles;
        }


        //public IEnumerable<Vehicle> Vehicles { get; }

        public bool SIsFull { get; }
        
        public int SGarageSlots { get; }

        public int SCapacity { get; }
      
        public string SName { get; }


        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.SGarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }


            if (garageSlot <= 0)
            {
                throw new InvalidOperationException("No vehicle in this garage slot");
            }

            var garageItem = this.Garage.ElementAt(garageSlot);
            return garageItem;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {

            /*  if (this.GarageSlots != null)
              {
                  throw new InvalidOperationException("No room in garage!");
              }*/
        //    int[] target = new int[100];


            var garageItem = this.Garage.ElementAt(garageSlot);

       //     Array.Copy(garageItem, deliveryLocation);

            return garageSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.SIsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            GetVehicle(garageSlot);
            return garageSlot;
        }
    }
}