using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPIsCode.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public required string ProductName { get; set; }

        //Foreign key property
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        //public Category Category { get; set; }
        public required string Price { get; set; }
        public required int Stock { get; set; }

        //public ICollection<Order> orders { get; set; }
    }
}
