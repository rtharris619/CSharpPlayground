using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals.Linq
{
    public class LinqLibrary
    {
        public void Driver()
        {
            TestGrouping();
        }

        public void TestGrouping()
        {
            var securities = new List<Security>
            {
                new Security{ Description = "Term Loans"},
                new Security{ Description = "Term Loans"},
                new Security{ Description = "Hire Purchase"},
            };

            var descriptionList = securities.GroupBy(x => x.Description).Select(x => x.Key).ToList();
            var desc = string.Join(", ", descriptionList);
            Console.WriteLine(desc);
        }

    }
   
    public class Security
    {
        public string Description { get; set; }
    }
}
