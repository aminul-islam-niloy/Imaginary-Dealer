using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace Imaginary_Dealer.Models.ViewModels
{
    public class BikeViewModelSection
    {
        public Bike Bike { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }

        // Constructor
        public BikeViewModelSection()
        {
            PaymentMethods = PaymentMethodList();
        }

        // Populate Payment Method directly
        private static List<PaymentMethod> PaymentMethodList()
        {
            var methodList = new List<PaymentMethod>
            {
                new PaymentMethod("Cash on", "Cash on Delivery"),
                new PaymentMethod("Moblile Banking", "bKash, Nogod, or Rocket"),
                new PaymentMethod("Banking", "Banking")
            };
            return methodList;
        }
    }

    // PaymentMethod class
    public class PaymentMethod
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public PaymentMethod(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
