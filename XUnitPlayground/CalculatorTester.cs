using CSharpPlayground.Testing.Calculator.CalculatorPkg;
using CSharpPlayground.Testing.Calculator.MoneyExchangeRatePkg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitPlayground
{
    public class CalculatorTester
    {
        private IUSD_ZAR_ExchangeRateFeed prvGetMockExchangeRateFeed()
        {
            Mock<IUSD_ZAR_ExchangeRateFeed> mockObject = new Mock<IUSD_ZAR_ExchangeRateFeed>();
            mockObject.Setup(m => m.GetActualUSDValue()).Returns(20);
            return mockObject.Object;
        }

        //[Fact(Description = "Divide 9 by 3. Expected result is 3.")]
        [Fact]
        public void TC1_Divide9By3()
        {
            IUSD_ZAR_ExchangeRateFeed feed = prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.Divide(9, 3);
            int expectedResult = 3;
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //[Test(Description = "Convert 1 USD to ZAR. Expected result is 20.")]
        public void TC3_ConvertUSDtoCLPTest()
        {
            IUSD_ZAR_ExchangeRateFeed feed = prvGetMockExchangeRateFeed();
            ICalculator calculator = new Calculator(feed);
            int actualResult = calculator.ConvertUSDtoZAR(1);
            int expectedResult = 20;
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
