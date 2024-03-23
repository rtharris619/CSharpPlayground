using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Strategy
{
    public class CsvRenderStrategy : IRenderStrategy
    {
        public string Render(string data)
        {
            return $"data,{data}";
        }
    }
}
