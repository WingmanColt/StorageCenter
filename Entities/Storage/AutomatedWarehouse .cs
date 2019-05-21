using System.Collections;
using System.Collections.Generic;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storage
{

    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name)
            : base(name: name, capacity: 1, garageSlots: 2, isFull:false)
        {
        }


    }
}