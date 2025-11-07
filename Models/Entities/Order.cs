using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPIsCode.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("Customer")]
        //public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("Product")]
        //public Product Product { get; set; }
        public required string ProductName { get; set; }
        public required int Quantity { get; set; }
        public required string Price { get; set; }
        public required string TotalAmount { get; set; }
        public required DateTime OrderDate { get; set; }
    }
}
