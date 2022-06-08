using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session57
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            //     a
            //    / \
            //   b   c
            //  /   / \ \
            // g   d   e f
            var tree = new Node<char>('a');
            tree.Children = new List<Node<char>> { new Node<char>('b'), new Node<char>('c') };
            tree.Children[0].Children = new List<Node<char>> { new Node<char>('g') };
            tree.Children[1].Children = new List<Node<char>> { new Node<char>('d'), new Node<char>('e'), new Node<char>('f') };

            // a
            // b c
            // g d e f

            WriteLine(LevelPrint(tree));
        }

        private string LevelPrint(Node<char> node)
        {
            var result = "";
            var queue = new Queue<Node<char>>();
            queue.Enqueue(node);           

            while (queue.Any())
            {
                int num = queue.Count();

                while (num > 0)
                {
                    var current = queue.Dequeue();
                    result += current.ToString();

                    if (current.Children != null && current.Children.Any())
                    {
                        foreach (var child in current.Children)
                        {
                            queue.Enqueue(child);
                        }
                    }
                    num--;                    
                }
                result += "\n";
            }

            return result;
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; } = new List<Node<T>>();

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
