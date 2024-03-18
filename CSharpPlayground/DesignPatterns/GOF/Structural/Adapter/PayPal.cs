using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Adapter
{
    public class PayPal
    {
        public void SendPayment(decimal amount)
        {
            Console.WriteLine($"Paying via PayPal: {amount}");
        }
    }
}
