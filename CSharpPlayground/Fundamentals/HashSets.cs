using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class HashSets
    {
        public void Driver()
        {
            var list = GetBPNumbersForCollateralRefresh("1");
            Console.WriteLine(string.Join(',', list));
        }

        private List<string> GetBPNumbersForCollateralRefresh(string currentBPNumber)
        {
            //var bpNumbers = new List<string>() { currentBPNumber };
            var hash = new HashSet<string>() { currentBPNumber };

            var temp = new List<string>() { "1", "2", "2" };

            temp.ForEach(x =>
            {
                hash.Add(x);
            });

            return hash.ToList();
        }
    }
}
