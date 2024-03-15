using CSharpPlayground.Testing.Calculator.MoneyExchangeRatePkg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Testing.Calculator.CalculatorPkg
{
    public class Calculator : ICalculator
    {
        private IUSD_ZAR_ExchangeRateFeed _exchangeRateFeed;

        public Calculator(IUSD_ZAR_ExchangeRateFeed exchangeRateFeed)
        {
            _exchangeRateFeed = exchangeRateFeed;
        }

        public int Add(int param1, int param2)
        {
            throw new NotImplementedException();
        }

        public int ConvertUSDtoZAR(int unit)
        {
            return unit * _exchangeRateFeed.GetActualUSDValue();
        }

        public int Divide(int param1, int param2)
        {
            return param1 / param2;
        }

        public int Multipy(int param1, int param2)
        {
            throw new NotImplementedException();
        }

        public int Subtract(int param1, int param2)
        {
            throw new NotImplementedException();
        }
    }
}
