using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session53
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var prices = new List<int> { 9, 11, 8, 5, 7, 10 };
            WriteLine(MaximumProfitImproved(prices));
        }

        // O(n^2)
        private int MaximumProfit(List<int> prices)
        {
            var maxProfit = 0;
            for (int i = 0; i < prices.Count(); i++)
            {
                for (int j = i; j < prices.Count(); j++)
                {
                    maxProfit = Math.Max(maxProfit, prices[j] - prices[i]);
                }
            }
            return maxProfit;
        }

        // O(n)
        private int MaximumProfitImproved(List<int> prices)
        {
            var maxProfit = 0;
            var maxCurrentPrice = 0;

            for (int i = prices.Count() - 1; i >= 0; i--)
            {
                maxCurrentPrice = Math.Max(maxCurrentPrice, prices[i]); // 10 10 10
                maxProfit = Math.Max(maxProfit, maxCurrentPrice - prices[i]); // 0 3 5
            }

            return maxProfit;
        }
    }
}
