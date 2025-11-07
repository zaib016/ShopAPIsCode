using System.ComponentModel.DataAnnotations;

namespace ShopAPIsCode.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required string ZipCode { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
