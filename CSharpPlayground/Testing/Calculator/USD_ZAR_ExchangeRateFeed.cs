using CSharpPlayground.Testing.Calculator.MoneyExchangeRatePkg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Testing.Calculator
{
    public class USD_ZAR_ExchangeRateFeed : IUSD_ZAR_ExchangeRateFeed
    {
        public int GetActualUSDValue()
        {
            return 20;
        }
    }
}
