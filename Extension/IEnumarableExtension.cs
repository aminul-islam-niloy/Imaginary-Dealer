﻿using Imaginary_Dealer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Imaginary_Dealer.Extension
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> Items, int selectedValue = 0)
        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "---Select---",
                Value = "0"
            };
            List.Add(sli);
            foreach (var Item in Items)
            {
                sli = new SelectListItem
                {
                    Text = Item.GetPropertyValue("Name"),
                    Value = Item.GetPropertyValue("Id"),
                    Selected = Item.GetPropertyValue("Id").Equals(selectedValue.ToString())
                };
                List.Add(sli);
            }
            return List;
        }
    }
}