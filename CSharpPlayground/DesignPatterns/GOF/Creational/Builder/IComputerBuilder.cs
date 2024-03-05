using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Builder
{
    public interface IComputerBuilder
    {
        void BuildCPU();
        void BuildRAM();
        void BuildHardDrive();
        void BuildGraphicsCard();
        Computer GetComputer();
    }
}
