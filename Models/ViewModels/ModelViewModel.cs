using Microsoft.AspNetCore.Mvc.Rendering;

namespace Imaginary_Dealer.Models.ViewModels
{
    public class ModelViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<Brand> Brands { get; set; }

    }
}
