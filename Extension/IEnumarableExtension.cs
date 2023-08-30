using Imaginary_Dealer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Imaginary_Dealer.Extension
{
    public static class IEnumarableExtension
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> Items)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SelectListItem item = new SelectListItem
            {
                Text = "---Select---",
                Value = "0"
            };
            list.Add(item);

            foreach (var brand in Items)
            {
                item = new SelectListItem
                {
                    Text = brand.GetType().GetProperty("Name").GetValue(brand, null).ToString(),
                    Value = brand.GetType().GetProperty("Id").GetValue(brand, null).ToString()
                };
                list.Add(item);
            }
            return list;
        }
    }
}
