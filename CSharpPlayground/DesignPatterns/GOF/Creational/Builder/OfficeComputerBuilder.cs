using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DesignPatterns.GOF.Creational.Builder
{
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void BuildCPU()
        {
            _computer.CPU = "Intel Core i5-9400";
        }

        public void BuildRAM()
        {
            _computer.RAM = "16GB DDR4 2666MHz";
        }

        public void BuildHardDrive()
        {
            _computer.HardDrive = "512GB NVMe SSD";
        }

        public void BuildGraphicsCard()
        {
            _computer.GraphicsCard = "Integrated Intel UHD Graphics 630";
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
