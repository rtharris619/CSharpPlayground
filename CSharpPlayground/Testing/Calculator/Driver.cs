using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using CSharpPlayground.Testing.Calculator.MoneyExchangeRatePkg;

namespace CSharpPlayground.Testing.Calculator
{
    public class Driver
    {
        public static void Run()
        {
            Console.WriteLine("Running Moqs...");

            var feed = new USD_ZAR_ExchangeRateFeed();

            var calculator = new CalculatorPkg.Calculator(feed);

            Console.WriteLine(calculator.ConvertUSDtoZAR(1));
        }
    }
}
