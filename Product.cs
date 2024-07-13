namespace ReductioAndAbsurdum
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int ProductTypeId { get; set; }

        public Product(string name, decimal price, bool available, int productTypeId)
        {
            Name = name;
            Price = price;
            Available = available;
            ProductTypeId = productTypeId;
        }
    }
}