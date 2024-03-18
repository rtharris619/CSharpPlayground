using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Adapter
{
    public class PaymentProcessor
    {
        public void ProcessPayment(IPaymentGateway paymentGateway, string merchantId, decimal amount)
        {
            paymentGateway.ProcessPayment(merchantId, amount);
        }
    }
}
