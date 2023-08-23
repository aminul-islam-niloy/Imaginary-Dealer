using System.ComponentModel.DataAnnotations;

namespace Imaginary_Dealer.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
       
       
    }
}
