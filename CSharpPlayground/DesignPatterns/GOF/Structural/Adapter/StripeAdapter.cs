using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Adapter
{
    public class StripeAdapter : IPaymentGateway
    {
        private readonly Stripe _stripe;

        public StripeAdapter(Stripe stripe)
        {
            _stripe = stripe;
        }

        public void ProcessPayment(string merchantId, decimal amount)
        {
            _stripe.MakePayment(merchantId, amount);
        }
    }
}
