using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Entities.Vehicles
{
    using Products;
    public class Vehicle
    {
        private readonly List<Product> vehicles;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.vehicles = new List<Product>();
        }

        public int Capacity { get; }

        public bool IsFull { get; }

        public bool IsEmpty { get; }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.vehicles.AsReadOnly();
            }
        }

        public void LoadProduct(Product product)
        {
            if (product.PWeight > this.Capacity)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.vehicles.Add(product);
        }

        public Product Unload()
        {
            if (IsEmpty)
            {
             throw new InvalidOperationException("No products left in vehicle!");
            }

             var lastItem = vehicles.Last();
             this.vehicles.Remove(lastItem);

            return lastItem;
        }

    }
}