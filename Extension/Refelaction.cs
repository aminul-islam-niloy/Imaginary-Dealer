using Imaginary_Dealer.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Imaginary_Dealer.Extension
{
    public static class Refelaction
    {
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();

            
        }
    }
}
