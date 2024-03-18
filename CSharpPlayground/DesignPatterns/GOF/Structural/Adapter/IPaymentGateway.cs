using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Adapter
{
    public interface IPaymentGateway
    {
        void ProcessPayment(string merchantId, decimal amount);
    }
}
