using Microsoft.AspNetCore.Mvc.Rendering;

namespace Imaginary_Dealer.Models.ViewModels
{
    public class ModelViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<Brand> Brands { get; set; }

        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Brand> Items)
        {
            List<SelectListItem> Makelist = new List<SelectListItem>();
            SelectListItem item = new SelectListItem
            {
                Text = "---Select---",
                Value = "0"
            };
            Makelist.Add(item);

            foreach (Brand brand in Items)
            {
                item = new SelectListItem
                {
                    Text = brand.Name,
                    Value = brand.Id.ToString()
                };
                Makelist.Add(item);
            }
            return Makelist;
        }

    }
}
