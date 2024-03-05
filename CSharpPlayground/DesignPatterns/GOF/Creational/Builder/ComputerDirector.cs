using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Builder
{
    public class ComputerDirector
    {
        private IComputerBuilder _computerBuilder;

        public ComputerDirector(IComputerBuilder computerBuilder)
        {
            _computerBuilder = computerBuilder;
        }

        public void BuildComputer()
        {
            _computerBuilder.BuildCPU();
            _computerBuilder.BuildRAM();
            _computerBuilder.BuildHardDrive();
            _computerBuilder.BuildGraphicsCard();
        }

        public Computer GetComputer()
        {
            return _computerBuilder.GetComputer();
        }
    }
}
