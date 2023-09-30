using System.ComponentModel.DataAnnotations;

namespace Imaginary_Dealer.Models
{
    public class Bike
    {
        public int Id { get; set; }
     
        public Brand Brand { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Brand")]
        public int BrandId  { get; set; }

        [RegularExpression("^[1-9]*$", ErrorMessage = "Select Model")]
        public Model Model { get; set; }
        public int ModelID { get; set; }

        [Required(ErrorMessage = "Provide year")]
        [Range(2000,2024,ErrorMessage ="Invalid Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Provide Mileage ")]
        [Range(1, int.MaxValue,ErrorMessage ="Provide Mileage")]
        public int Mileage { get; set;}
        
        [Required(ErrorMessage = "Provide Features")]
        public string Features { get; set; }
        
        [Required(ErrorMessage = "Provide SellerName")]
        public string SellerName { get; set; }
        [Required(ErrorMessage = "Provide SellerEmail")]
        public string SellerEmail { get; set; }

        [Required(ErrorMessage = "Provide SellerPhone")]
        public string SellerPhone { get; set; }

        //[Required(ErrorMessage = "Provide SellerLocation")]
        //public string SellerLocation { get; }


        [Required(ErrorMessage = "Provide Price")]
        public int  Price { get; set; }

      //  [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Select Paymen Method")]
        public string PaymentMethod { get; set; }
        public string ImagePath { get; set; }



    }
}
