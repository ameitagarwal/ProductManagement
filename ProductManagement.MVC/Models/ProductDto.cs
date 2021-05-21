using System;

namespace ProductManagement.MVC.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
    }
}
