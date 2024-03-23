using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Behavioral.Strategy
{
    public class DataRenderer
    {
        private IRenderStrategy _renderStrategy;

        public DataRenderer(IRenderStrategy renderStrategy)
        {
            _renderStrategy = renderStrategy;
        }

        public void SetRenderStrategy(IRenderStrategy renderStrategy)
        {
            _renderStrategy = renderStrategy;
        }

        public string RenderData(string data)
        {
            return _renderStrategy.Render(data);
        }
    }
}
