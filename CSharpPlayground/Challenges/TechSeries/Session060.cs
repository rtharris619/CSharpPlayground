using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpPlayground.Challenges.TechSeries.Session60
{
    public class Session
    {
        public void Driver()
        {
            Example1();
        }

        private void Example1()
        {
            var trie = Build(new List<string> { "dog", "dark", "cat", "door", "dodge" });
            var result = AutoComplete(trie, "do");
            Console.WriteLine(string.Join(",", result));
        }

        public class Node
        {
            public bool IsWord { get; set; }
            public Dictionary<char, Node> Children { get; set; } = new Dictionary<char, Node>(); // 'a', Node(true, {})

            public Node(bool isWord)
            {
                IsWord = isWord;
            }
        }

        public Node Build(List<string> words)
        {
            var trie = new Node(false);
            foreach (var word in words)
            {
                var current = trie;
                foreach (var ch in word)
                {
                    if (!current.Children.ContainsKey(ch))
                    {
                        current.Children.Add(ch, new Node(false));
                    }
                    current = current.Children[ch];
                }
                current.IsWord = true;
            }
            return trie;
        }

        // do => dog, door, dodge
        public List<string> AutoComplete(Node trie, string word)
        {         
            var current = trie;

            foreach (var ch in word)
            {
                if (!current.Children.ContainsKey(ch))
                {
                    return new List<string>();
                }
                current = current.Children[ch];
            }
            var result = new List<string>();
            DFSIterative(current, word, result);
            return result;
        }

        public void DFS(Node current, string prefix, List<string> words)
        {
            if (current.IsWord) words.Add(prefix);

            foreach (var keyValuePair in current.Children)
            {
                DFS(current.Children[keyValuePair.Key], prefix + keyValuePair.Key, words);
            }
        }

        public void DFSIterative(Node current, string prefix, List<string> words)
        {
            var stack = new Stack<StackObject>();
            stack.Push(new StackObject(current, prefix));

            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item.Node.IsWord) words.Add(item.Prefix);

                foreach (var keyValuePar in item.Node.Children)
                {
                    var child = item.Node.Children[keyValuePar.Key];
                    stack.Push(new StackObject(child, item.Prefix + keyValuePar.Key));
                }
            }
        }

        public class StackObject
        {
            public Node Node { get; set; }
            public string Prefix { get; set; }
            public StackObject(Node node, string prefix)
            {
                Node = node;
                Prefix = prefix;
            }
        }

    }
}
