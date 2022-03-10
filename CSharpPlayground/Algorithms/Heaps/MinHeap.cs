using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Algorithms.Heaps
{
    public class MinHeapDriver
    {
        public void Driver()
        {
            MinHeapTest();
        }

        private void MinHeapTest()
        {
            var heap = new MinHeap(6);
            heap.Push(3);
            heap.Push(4);
            heap.Push(2);
            heap.Push(1);
            heap.Push(6);
            heap.Push(7);
            WriteLine(heap.Pop());
            WriteLine(heap.Pop());
        }
    }

    public class MinHeap
    {
        public int[] HeapData { get; set; }
        public int Capacity { get; set; }
        public int CurrentHeapSize { get; set; }

        public MinHeap(int n)
        {
            Capacity = n;
            HeapData = new int[Capacity];
            CurrentHeapSize = 0;
        }

        public int Parent(int key)
        {
            return (key - 1) / 2;
        }

        public int Left(int key)
        {
            return 2 * key + 1;
        }

        public int Right(int key)
        {
            return 2 * key + 2;
        }

        public bool Push(int value)
        {
            if (CurrentHeapSize == Capacity)
            {
                return false;
            }

            int i = CurrentHeapSize;
            HeapData[i] = value;
            CurrentHeapSize++;

            while (i != 0 && HeapData[i] < HeapData[Parent(i)])
            {
                (HeapData[i], HeapData[Parent(i)]) = (HeapData[Parent(i)], HeapData[i]);
                i = Parent(i);
            }

            return true;
        }

        public int GetMinimum()
        {
            return HeapData[0];
        }

        public int Pop()
        {
            if (CurrentHeapSize <= 0)
            {
                return int.MaxValue;
            }

            if (CurrentHeapSize == 1)
            {
                CurrentHeapSize--;
                return HeapData[0];
            }

            int root = HeapData[0];
            HeapData[0] = HeapData[CurrentHeapSize - 1];

            Heapify(0);

            return root;
        }

        private void Heapify(int key)
        {
            int left = Left(key);
            int right = Right(key);

            int smallest = key;

            if (left < CurrentHeapSize && HeapData[left] < HeapData[smallest])
            {
                smallest = left;
            }
            if (right < CurrentHeapSize && HeapData[right] < HeapData[smallest])
            {
                smallest = right;
            }

            if (smallest != key)
            {
                (HeapData[key], HeapData[smallest]) = (HeapData[smallest], HeapData[key]);
                Heapify(smallest);
            }
        }
    }
}
