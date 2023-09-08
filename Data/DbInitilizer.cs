using Imaginary_Dealer.AppDBContex;
using Imaginary_Dealer.Data;
using Imaginary_Dealer.Models;
using Imaginary_Dealer.RolesAction;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace vroom.Data
{
    public class DBInitializer : IDbInitializer
    {
        private readonly Im_Dealer_DB_Contex _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DBInitializer(Im_Dealer_DB_Contex db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public object RolesAction { get; private set; }

        public async void Initialize()
        {
            //Add pending migration if exists
            if (_db.Database.GetPendingMigrations().Count() == 0)
            {
                _db.Database.Migrate();
            }

           // Exit if role already exists
            if (_db.Roles.Any(r => r.Name == Roles.Admin)) return;

            //Create Admin role
            _roleManager.CreateAsync(new IdentityRole(Roles.Admin)).GetAwaiter().GetResult();

          //  Create Admin user
            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@gmail.com",
                EmailConfirmed = true,
            }, "@Admin12345").GetAwaiter().GetResult();

          //  Assign role to Admin user
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync("Admin"), Roles.Admin);

        }
    }
}
