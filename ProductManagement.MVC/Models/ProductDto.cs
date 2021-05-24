using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.MVC.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [MinLength(3, ErrorMessage = "Lenght should be more than 3")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Product Code")]
        public string ProductCode { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}
