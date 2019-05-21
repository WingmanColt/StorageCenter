using System.Collections;
using System.Collections.Generic;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storage
{

    public class Warehouse : Storage
    {
        public Warehouse(string name)
            : base(name: name, capacity: 10, garageSlots: 10, isFull:false)
        {
        }


    }
}