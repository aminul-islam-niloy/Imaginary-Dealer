using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imaginary_Dealer.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Office Phone ")]
        public string OthersPhoneNumber { get; set; }

        [NotMapped]
        public bool isAdmin { get; set; }
    }
}
