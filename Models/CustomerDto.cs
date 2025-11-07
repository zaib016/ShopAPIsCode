namespace ShopAPIsCode.Models
{
    public class CustomerDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required string ZipCode { get; set; }
    }
}
