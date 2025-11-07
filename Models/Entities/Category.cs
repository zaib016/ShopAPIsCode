using System.ComponentModel.DataAnnotations;

namespace ShopAPIsCode.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string Description { get; set; }

        //public ICollection<Product> products { get; set; }
    }
}
