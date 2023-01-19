using System;
using System.Collections.Generic;
namespace AutoComplete
{
    public class Trie
    {
        public TrieNode Root;

        public Trie()
        {
            Root = new TrieNode('\0');
        }

        public void Insert(string word)
        {
            var node = Root;
            foreach (var c in word)
            {
                node = Helpers.AddOrGetChildNode(node, c);
            }
            node.IsEndOfWord = true;
        }

        public bool Remove(string word)
        {
            var node = Root;
            Stack<TrieNode> stack = new();
            try
            {
                foreach (var c in word)
                {
                    stack.Push(node);
                    node = node.Children[c];
                }
                node.IsEndOfWord = false;
                return !node.IsEndOfWord;
            }
            catch (KeyNotFoundException)
            {
                return false;
            }
        }
    }
}
