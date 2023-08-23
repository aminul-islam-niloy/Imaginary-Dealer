using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imaginary_Dealer.Models
{
    public class Model
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public Brand Make { get; set; }

        [ForeignKey("Make")]
        public int BrandF_K { get; set;}




    }
}
