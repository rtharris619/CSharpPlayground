using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CSharpPlayground.Helpers;
using CSharpPlayground.Algorithms.Heaps;

namespace CSharpPlayground.Challenges.TechSeries.Session59
{
    public class Session
    {
        public void Driver()
        {
            Example2();
        }

        private void Example1()
        {
            FindClosestPoints(new List<List<int>> { 
                new List<int> { 1, 1 },
                new List<int> { 3, 3 },
                new List<int> { 2, 2 },
                new List<int> { 4, 4 },
                new List<int> { -1, -1 },
            }, 3).Display();
        }

        private void Example2()
        {
            FindClosestPointsHeapify(new List<List<int>> {
                new List<int> { 1, 1 },
                new List<int> { 3, 3 },
                new List<int> { 2, 2 },
                new List<int> { 4, 4 },
                new List<int> { -1, -1 },
            }, 3).Display();
        }

        private int CalculateDistance(List<int> point)
        {
            return point[0] * point[0] + point[1] * point[1];
        }

        // O (n log n)
        private List<List<int>> FindClosestPoints(List<List<int>> points, int k)
        {
            var result = points.OrderBy(x => x[0] * x[0] + x[1] * x[1]).ToList();
            return result.Take(k).ToList();
        }

        private List<List<int>> FindClosestPointsHeapify(List<List<int>> points, int k)
        {
            var heap = new MinHeap(points.Count);
            var data = new List<int>();

            foreach (var point in points)
            {
                data.Add(CalculateDistance(point));
                //data.Add(point[0]);
            }
            heap.Heapify(data);

            var result = new List<List<int>>();

            for (int i = 0; i < k; i++)
            {
                result.Add(new List<int> { heap.Pop(), 0 });
            }

            return result;
        }

    }
}
