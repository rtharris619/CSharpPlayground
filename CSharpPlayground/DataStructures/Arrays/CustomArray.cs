using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.DataStructures.Arrays
{
    public class CustomArray
    {
        private int[] Array;
        private int UpperBound;
        private int NumberOfElements;

        public CustomArray(int size)
        {
            Array = new int[size];
            UpperBound = size - 1;
            NumberOfElements = 0;
        }

        public void Insert(int item)
        {
            Array[NumberOfElements] = item;
            NumberOfElements++;
        }

        public void DisplayElements()
        {
            for (int i = 0; i <= UpperBound; i++)
            {
                Console.Write(Array[i] + " ");
            }
        }

        public void Clear()
        {
            for (int i = 0; i <= UpperBound; i++)
            {
                Array[i] = 0;
            }
            NumberOfElements = 0;
        }
    }

    public class TestCustomArray
    {
        public void Driver()
        {
            RandomList();
        }

        private void ContiguousList()
        {
            CustomArray nums = new CustomArray(50);
            for (int i = 0; i <= 49; i++)
            {
                nums.Insert(i);
            }
            nums.DisplayElements();
        }

        private void RandomList()
        {
            CustomArray nums = new CustomArray(10);
            Random rnd = new Random(100);
            for (int i = 0; i < 10; i++)
            {
                nums.Insert((int)(rnd.NextDouble() * 100));
            }
            nums.DisplayElements();
        }
    }
}
