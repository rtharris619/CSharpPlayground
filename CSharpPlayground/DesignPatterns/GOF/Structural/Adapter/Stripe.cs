using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Structural.Adapter
{
    public class Stripe
    {
        public void MakePayment(string merchangeId, decimal amount)
        {
            Console.WriteLine($"Paying via Stripe: {amount}");
        }
    }
}
