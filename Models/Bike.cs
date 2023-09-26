using System.ComponentModel.DataAnnotations;

namespace Imaginary_Dealer.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public int BrandId  { get; set; }
        public Model Model { get; set; }
        public int ModelID { get; set; }

        [Required]
        public int Year { get; set; }
       
        [Required]
        public int Mileage { get; set;}
      
        public string Features { get; set; }

        public string SellerName { get; set; }
        public string SellerEmail { get; set; }
       
        [Required]
        public string SellerPhone { get; set; }
        
        [Required]
        public string SellerLocation { get;}


        [Required]
        public int  Price { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
        public string ImagePath { get; set; }



    }
}
