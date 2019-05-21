using System;
using StorageMaster.Entities.Products;

namespace StorageMaster.Entities.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string name, double price)
        {
            Product product;
            switch (name)
            {
                case "Gpu":
                product = new Gpu(price);               
                    break;
                case "HardDrive":
                    product = new HardDrive(price);
                    break;
                case "Ram":
                    product = new Ram(price);
                    break;
                case "SolidStateDrive":
                    product = new SolidStateDrive(price);
                    break;

                default:
                    throw new InvalidOperationException($"Invalid product type!");
            }

            return product;
        }
    }
}