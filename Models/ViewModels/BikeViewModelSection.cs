using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace Imaginary_Dealer.Models.ViewModels
{
    public class BikeViewModelSection
    {
        public Bike Bike { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }

        private List<PaymentMethod> MethodList = new List<PaymentMethod>();

        //populate  Payment Method directly
        private List<PaymentMethod> PaymentMethodList()
        {
            MethodList.Add(new PaymentMethod("Cash on", "Cash on Delivery"));
            MethodList.Add(new PaymentMethod("Moblile Banking", "bKash,Nogod or Rocket"));
            MethodList.Add(new PaymentMethod("Banking", "Banking"));
            return MethodList;
        }

        // it automatic added at the time of object initliazation
        public BikeViewModelSection()
        {
            PaymentMethods = PaymentMethodList();
        }

    }

    // for payment method select

    public class PaymentMethod
    {
        public String Id { get; set; }
        public String Name { get; set; }

        public PaymentMethod(String id, String name)
        {
            Id = id;
            Name = name;
        }
    }

}
