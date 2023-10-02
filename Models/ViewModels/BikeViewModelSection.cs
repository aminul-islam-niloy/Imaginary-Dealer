using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace Imaginary_Dealer.Models.ViewModels
{
    public class BikeViewModelSection
    {
        public Bike Bike { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }

   

        private List<PaymentMethod> PList= new List<PaymentMethod>();

        // Populate Payment Method directly
        private  List<PaymentMethod> PaymentList()
        {

            PList.Add(new PaymentMethod("Cash on", "Cash on Delivery"));
            PList.Add(new PaymentMethod("Moblile Banking", "bKash, Nogod, or Rocket"));
            PList.Add(new PaymentMethod("Banking", "Banking"));
            return PList;

        }

        // Constructor
        public BikeViewModelSection()
        {
            PaymentMethods = PaymentList();
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
