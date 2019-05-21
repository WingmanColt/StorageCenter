using System;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Storage;
using StorageMaster.IO;
using StorageMaster.IO.Contracts;

namespace StorageMaster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var master = new StorageMaster(reader, writer);
            master.Run();
        }
    }
}
