using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CSharpPlayground.Helpers;
using CSharpPlayground.Algorithms.Heaps;

namespace CSharpPlayground.Challenges.TechSeries.Session34
{
    public class Session
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            var slots = new List<List<int>> { new List<int> { 0, 10 }, new List<int> { 10, 20 } };
            WriteLine(MeetingRooms(slots)); // 1
        }

        private void Example2()
        {
            var slots = new List<List<int>> { new List<int> { 20, 30 }, new List<int> { 10, 21 }, new List<int> { 0, 50 } };
            WriteLine(MeetingRooms(slots)); // 3
        }

        private int MeetingRooms(List<List<int>> slots)
        {
            slots = slots.OrderBy(x => x[0]).ToList();

            var maxRooms = 0;
            var slotEnds = slots.Select(x => x[1]).ToList();
            var heap = new MinHeap(slots.Count());

            foreach (var slot in slots)
            {
                while (slotEnds.Count() > 0 && slotEnds[0] <= slot[0])
                {
                    heap.Pop();
                }
                heap.Push(slot[1]);
                maxRooms = Math.Max(maxRooms, slotEnds.Count());
            }

            return maxRooms;
        }
    }
}
