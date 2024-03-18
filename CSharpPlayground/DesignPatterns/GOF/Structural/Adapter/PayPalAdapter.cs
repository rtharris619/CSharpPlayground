using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Adapter
{
    public class PayPalAdapter : IPaymentGateway
    {
        private readonly PayPal _payPal;

        public PayPalAdapter(PayPal payPal)
        {
            _payPal = payPal;
        }

        public void ProcessPayment(string merchantId, decimal amount)
        {
            _payPal.SendPayment(amount);
        }
    }
}
