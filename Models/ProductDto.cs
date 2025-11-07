using System.ComponentModel.DataAnnotations.Schema;
using ShopAPIsCode.Models.Entities;

namespace ShopAPIsCode.Models
{
    public class ProductDto
    {
        public required string ProductName { get; set; }

        //Foreign key property
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        //public Category Category { get; set; }
        public required string Price { get; set; }
        public required int Stock { get; set; }
    }
}
