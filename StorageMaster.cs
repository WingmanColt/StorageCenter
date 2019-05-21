using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Factories;

namespace StorageMaster
{
    using IO.Contracts;
    public class StorageMaster
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;


        private readonly List<Product> product;
        private readonly List<Vehicle> vehicle;
        private readonly List<Storage> storage;

        private readonly ProductFactory ProductFactory;
        private readonly VehicleFactory VehicleFactory;
        private readonly StorageFactory StorageFactory;




        public StorageMaster(IReader reader, IWriter writer)
        {

            this.reader = reader;
            this.writer = writer;

            this.vehicle = new List<Vehicle>();
            this.product = new List<Product>();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string command = this.reader.ReadLine();

                if (command == "END")
                {
                    break;
                }

                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine("Error:" + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("Error:" + e.Message);
                }

                if (this.isRunning == false)
                {
                    this.isRunning = false;
                }
            }
        }



        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (commandName)
            {
                case "AddProduct":
                    
                    var type = args[0];
                    var price = double.Parse(args[1]);

                    output = this.AddProduct(type, price);
                    break;

                case "RegisterStorage":

                    var typeStorage = args[0];
                    var nameStorage = args[1];

                    output = this.RegisterStorage(typeStorage, nameStorage);
                    break;

                case "SelectVehicle":

                    var Name = args[0];
                    var Slot = int.Parse(args[1]);

                    output = this.SelectVehicle(Name, Slot);
                    break;

                case "LoadVehicle":

                    var LName1 = args[0];
                    var Slot2 = int.Parse(args[1]);
                    var LName2= args[2];


                    output = this.SelectVehicle(LName1, Slot2);
                    break;

                case "SendVehicleTo":

            var sourceName = args[0];
            var garageSlot = int.Parse(args[1]);
            var destName = args[1];

             output = this.SendVehicleTo(sourceName, garageSlot, destName);
            break;

                case "UnloadVehicle":

                    var storageName = args[0];
                    var garageSlot2 = int.Parse(args[1]);

                    output = this.UnloadVehicle(storageName, garageSlot2);
                    break;

                case "GetStorageStatus":

                    var storageName2 = args[0];

                    output = this.GetStorageStatus(storageName2);
                    break;

                case "GetSummary":
                    
                    output = this.GetSummary();
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }



        
        public string AddProduct(string type, double price)
        {

            switch (type)
            {

                case "Gpu":
                {
                    var gpu = this.ProductFactory.CreateProduct(type, price);
                    product.Add(gpu);
                    }
                    break;

                case "HardDrive":
                {
                    var hard = this.ProductFactory.CreateProduct(type, price);
                    product.Add(hard);
                }
                    break;

                case "Ram":
                {
                    var hard = this.ProductFactory.CreateProduct(type, price);
                    product.Add(hard);
                }
                    break;

                case "SolidStateDrive":
                {
                    var hard = this.ProductFactory.CreateProduct(type, price);
                    product.Add(hard);
                }
                    break;

                default: throw new InvalidOperationException("Invalid product type!");
            }


            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                {
                    var hard = this.StorageFactory.CreateStorage(type, name);
                    storage.Add(hard);
                }
                    break;

                case "DistributionCenter":
                {
                    var hard = this.StorageFactory.CreateStorage(type, name);
                    storage.Add(hard);
                }
                    break;

                case "Warehouse":
                {
                    var hard = this.StorageFactory.CreateStorage(type, name);
                    storage.Add(hard);
                }
                    break;

                default: throw new InvalidOperationException("Invalid storage type!");
            }


            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {



            throw new NotImplementedException();
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            throw new NotImplementedException();
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
             bool storageItem = this.storage.Any(i => i.GetType().Name == sourceName);
             bool garageItem = this.storage.Any(i => i.GetType().Name == destinationName);

            if (!storageItem)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            else if (!garageItem)
            {
                throw new InvalidOperationException("Invalid destination storage");
            }

          //  this.storage.Add(sourceGarageSlot);

            //if(this.storage.)
            var vehicleType = "Semi";
            var destinationGarageSlot = "1";

            return $"Sent {vehicleType} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var unloadedProductsCount = this.storage.Count();
            var productsInVehicle = this.vehicle.Count();

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            bool storageItem = this.storage.Any(i => i.GetType().Name == storageName);

            if (storageItem)
            {
                var value = 1; //(string)GetType().GetProperty("SCapacity").GetValue(this, null);
                var value2 = 2; //(string)GetType().GetProperty("PWeight").GetValue(this, null);
             writer.WriteLine(
                        $"Stock({value2}/{value}): [Gpu, Ram, HardDrive, SolidStateDrive]");

              }
            foreach (var item in this.vehicle)
            {
                writer.WriteLine($"Garage: [{item}]");
            }

            return GetStorageStatus(storageName);
        }

        public string GetSummary()
        {
            throw new NotImplementedException();

        }

    }
}