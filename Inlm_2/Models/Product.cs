using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Inlm_2.Models
{

    public enum Categories
    {
        TV,
        Ljud,
        Dator,
        Mobiltelefoni,
        Tillbehör
    }

    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string ArtNr { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Categories Category { get; set; }
        public List<Specification> Specifications { get; set; }
  
    }
}
