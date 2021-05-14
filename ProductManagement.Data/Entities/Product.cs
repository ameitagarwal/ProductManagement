namespace ProductManagement.Data.Entities
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
