using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Heaps
{
    public class MaxBinaryHeap
    {
        public List<int> Values { get; private set; }

        public MaxBinaryHeap()
        {
            Values = new List<int>();
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return (2 * parentIndex) + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return (2 * parentIndex) + 2;
        }

        /// <summary>
        /// Adds a new value to the heap
        /// </summary>
        /// <param name="value"></param>
        public void Push(int value)
        {
            Values.Add(value);

            if (Values.Count > 1)
                BubbleUp();
        }

        /// <summary>
        /// Bubbles up the newly added item to the correct spot in the heap
        /// </summary>
        private void BubbleUp()
        {
            int element = Values[Values.Count - 1];
            int currentIndex = Values.Count - 1;
            int currentParentIndex = GetParentIndex(currentIndex);

            while (currentParentIndex >= 0 && element > Values[currentParentIndex])
            {
                // swap
                Values[currentIndex] = Values[currentParentIndex];
                Values[currentParentIndex] = element;

                // update positions
                currentIndex = currentParentIndex;
                currentParentIndex = GetParentIndex(currentIndex);
            }
        }

        public int Pop()
        {
            if (!Values.Any())
                return -1;

            int max = GetRoot();

            int last = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);

            if (Values.Any())
            {
                Values[0] = last;
                SinkDown();
            }

            return max;
        }

        /// <summary>
        /// Rebalances the heap after popping off the root node
        /// </summary>
        private void SinkDown()
        {
            int index = 0;
            int nodeToSinkDown = Values[index];

            int leftChildIndex, rightChildIndex;
            int leftChildNode = int.MinValue;
            int rightChildNode = int.MinValue;
            int swapIndex = index;

            while (true)
            {
                bool swap = false;
                leftChildIndex = GetLeftChildIndex(index);
                rightChildIndex = GetRightChildIndex(index);

                if (leftChildIndex < Values.Count)
                {
                    leftChildNode = Values[leftChildIndex];
                    if (leftChildNode > nodeToSinkDown)
                    {
                        swap = true;
                        swapIndex = leftChildIndex;
                    }
                }

                if (rightChildIndex < Values.Count)
                {
                    rightChildNode = Values[rightChildIndex];
                    if ((!swap && rightChildNode > nodeToSinkDown) || (swap && rightChildNode > leftChildNode))
                    {
                        swap = true;
                        swapIndex = rightChildIndex;
                    }
                }

                if (!swap) break;

                Values[index] = Values[swapIndex];
                Values[swapIndex] = nodeToSinkDown;
                index = swapIndex;
            }
        }

        public int GetRoot()
        {
            return Values[0];
        }
    }

    public class MaxBinaryHeapTest
    {
        public void Driver()
        {
            var heap = new MaxBinaryHeap();
            heap.Push(1);
            heap.Push(10);
            heap.Push(12);
            heap.Push(13);
            heap.Push(4);
            heap.Push(5);
            Console.WriteLine(heap.GetRoot());

            heap.Pop();
            Console.WriteLine(heap.GetRoot());
        }
    }
}
