using Imaginary_Dealer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imaginary_Dealer.AppDBContex
{
    public class Im_Dealer_DB_Contex:IdentityDbContext<IdentityUser>
    {
        public Im_Dealer_DB_Contex(DbContextOptions<Im_Dealer_DB_Contex> options):base(options)
        {

        
        }  
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
