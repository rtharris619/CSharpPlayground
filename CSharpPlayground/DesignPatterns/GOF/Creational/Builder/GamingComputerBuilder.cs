using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Builder
{
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void BuildCPU()
        {
            _computer.CPU = "Intel Core i9-9900K";
        }

        public void BuildRAM()
        {
            _computer.RAM = "32GB DDR4 3200MHz";
        }

        public void BuildHardDrive()
        {
            _computer.HardDrive = "1TB NVMe SSD";
        }

        public void BuildGraphicsCard()
        {
            _computer.GraphicsCard = "NVIDIA GeForce RTX 2080 Ti";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
