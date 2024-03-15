using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Testing.Calculator.MoneyExchangeRatePkg
{
    public interface IUSD_ZAR_ExchangeRateFeed
    {
        int GetActualUSDValue();
    }
}
