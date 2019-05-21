using System.Collections;
using System.Collections.Generic;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storage
{

    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name)
            : base(name: name, capacity: 2, garageSlots: 5, isFull:false)
        {
        }


    }
}