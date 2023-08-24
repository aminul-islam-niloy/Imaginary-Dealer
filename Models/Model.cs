﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imaginary_Dealer.Models
{
    public class Model
    {
        public int Id { get; set; }
       
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandF_K { get; set;}




    }
}
