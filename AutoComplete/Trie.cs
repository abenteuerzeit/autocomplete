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
            var currentNode = Root;
            foreach (var c in word)
            {
                if (!currentNode.Children.ContainsKey(c))
                {
                    currentNode.Children.Add(c, new TrieNode(c));
                }

                currentNode = currentNode.Children[c];
            }
            currentNode.IsEndOfWord = true;
        }

        public bool Remove(string word)
        {
            var currentNode = Root;
            var stack = new Stack<TrieNode>();
            foreach (var c in word)
            {
                if (!currentNode.Children.ContainsKey(c))
                {
                    return false;
                }

                stack.Push(currentNode);
                currentNode = currentNode.Children[c];
            }
            if (!currentNode.IsEndOfWord)
            {
                return false;
            }

            currentNode.IsEndOfWord = false;
            if (currentNode.Children.Count == 0)
            {
                stack.Pop().Children.Remove(word[word.Length - 1]);
            }
            return true;
        }
    }
}
