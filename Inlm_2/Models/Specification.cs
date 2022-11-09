using System.ComponentModel.DataAnnotations;

namespace Inlm_2.Models
{
    public class Specification
    {
        
        public string Title { get; set; }
        public List<SpecInformation> SpecInfo { get; set; }
    }
}
