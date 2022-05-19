using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session49
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var tree = new Node(1);
            tree.Left = new Node(3);
            tree.Right = new Node(4);
            tree.Left.Left = new Node(2);
            tree.Left.Right = new Node(5);
            tree.Right.Right = new Node(7);
            //WriteLine(tree);
            var serializedTree = Serialize(tree);
            WriteLine(serializedTree);

            WriteLine(Deserialize(serializedTree));
        }

        private string Serialize(Node node)
        {
            if (node == null) return "#";
            return node.Value.ToString() + " " + Serialize(node.Left) + " " + Serialize(node.Right);
        }

        private Node Deserialize(string str)
        {            
            var values = str.Split();

            return DeserializeHelper(values);
        }

        int currentIndex = 0;

        private Node DeserializeHelper(string[] values)
        {
            if (values[currentIndex] == "#") return null;            

            var node = new Node(int.Parse(values[currentIndex]));

            currentIndex++;
            node.Left = DeserializeHelper(values);
            currentIndex++;
            node.Right = DeserializeHelper(values);
            return node;
        }

        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; } = null;
            public Node Right { get; set; } = null;

            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                string result = string.Empty;
                result += Value.ToString();
                if (Left != null) result += Left.ToString();
                if (Right != null) result += Right.ToString();
                return result;
            }
        }
    }
}
