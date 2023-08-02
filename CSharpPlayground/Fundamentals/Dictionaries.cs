using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Fundamentals
{
    public class Dictionaries
    {
        public void Driver()
        {
            TestDictionary();
        }

        private void TestDictionary()
        {
            var bps = new List<string> { "a", "b", "c", "a" };

            var notifiedTransporters = new Dictionary<string, bool>();

            foreach (var bp in bps) 
            {
                if (!notifiedTransporters.ContainsKey(bp))
                {
                    notifiedTransporters[bp] = true;
                    Console.WriteLine(bp);
                }
            }
        }
    }
}
