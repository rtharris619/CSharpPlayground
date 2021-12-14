using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlayground.Algorithms.Tries
{
    public class Node
    {
        public char Character { get; set; }
        public bool IsWord { get; set; }
        public List<Node?> Children { get; set; } = new List<Node?>();

        public Node(char character)
        {
            Character = character;
            IsWord = false;
            Children = Enumerable.Repeat((Node?)null, 26).ToList();
        }
    }

    public class Trie
    {
        public Node Root { get; set; }

        public Trie()
        {
            Root = new Node('\0');
        }

        public void Insert(string word)
        {
            var current = Root;
            for (var i = 0; i < word.Length; i++)
            {
                var character = word[i];
                var characterIndex = GetCharIndex(character);
                if (current.Children[characterIndex] == null)
                {
                    current.Children[characterIndex] = new Node(character);
                }
                current = current.Children[characterIndex];
            }
            current.IsWord = true;
        }

        public bool Search(string word)
        {
            var node = GetNode(word);
            return node != null && node.IsWord;
        }

        public bool StartsWith(string prefix)
        {
            var node = GetNode(prefix);
            return node != null;
        }

        private Node? GetNode(string word)
        {
            var current = Root;
            for (var i = 0; i < word.Length; i++)
            {
                var character = word[i];
                var characterIndex = GetCharIndex(character);
                if (current.Children[characterIndex] == null)
                    return null;
                current = current.Children[characterIndex];
            }
            return current;
        }

        private int GetCharIndex(char character)
        {
            return character - 'a';
        }
    }

    public class TrieTest
    {
        public void Driver()
        {
            var trie = new Trie();
            trie.Insert("cats");
            trie.Insert("cab");
            trie.Insert("can");
            var search = trie.Search("cats");
            Console.WriteLine(search);
            var startsWith = trie.StartsWith("cat");
            Console.WriteLine(startsWith);
        }
    }
}
