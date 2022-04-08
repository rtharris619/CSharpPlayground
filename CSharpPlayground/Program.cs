
using CSharpPlayground.Challenges.DCP;
using CSharpPlayground.Algorithms.Tries;
using CSharpPlayground.Algorithms.Dynamic;
using CSharpPlayground.Algorithms.Trees;
using CSharpPlayground.Algorithms.Queues;
using CSharpPlayground.Algorithms.Stacks;
using CSharpPlayground.Algorithms.Search;
using CSharpPlayground.Algorithms.Heaps;
using Graphs = CSharpPlayground.Algorithms.Graphs;
using CSharpPlayground.Fundamentals;
using CSharpPlayground.Algorithms.LinkedLists;
using CSharpPlayground.Fundamentals.Generics;
using CSharpPlayground.DesignPatterns.DependencyInversion;
using CSharpPlayground.DesignPatterns.Creational.Factory;
using CSharpPlayground.FSharpForFun;
using CSharpPlayground.Mathematics.Trigonometry;
using HackerRank = CSharpPlayground.Challenges.HackerRank;
using BinarySearch = CSharpPlayground.Challenges.BinarySearch;
using TechSeries = CSharpPlayground.Challenges.TechSeries;
using TestTiming = CSharpPlayground.Helpers.TestTiming;

namespace CSharpPlayground
{
    public class Program
    {
        public static void Main()
        {
            //new FSharpForFunDriver().Driver();
            //new HackerRank.Easy().Driver();
            //new BinarySearch.Easy().Driver();
            //new ObjectTrackingFactory().Driver();

            //new AbstractFactory().Driver();
            //new MinHeapDriver().Driver();
            //new Trigonometry().Driver();

            //new TestTiming().Driver();

            new Graphs.UndirectedGraph().Driver();

            //new TechSeries.Session35.Session().Driver();
        }
    }
}
