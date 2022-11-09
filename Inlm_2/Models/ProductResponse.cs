using System.ComponentModel.DataAnnotations;

namespace Inlm_2.Models
{
    public class ProductResponse
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ArtNr { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<Specification> Specifications { get; set; }
    }
}
