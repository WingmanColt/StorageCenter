namespace StorageMaster.Entities.Products
{
    public class Product
    {
        protected Product(double price, double weight)
        {
            this.Price = price;
            this.PWeight = weight;
        }

        public double Price { get; }

        public double PWeight { get; }
    }
}