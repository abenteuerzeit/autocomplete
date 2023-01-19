using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoComplete
{
    internal static class Helpers
    {

        internal static TrieNode AddOrGetChildNode(TrieNode node, char c) =>
            node.Children.ContainsKey(c) ? node.Children[c] : node.Children[c] = new TrieNode(c);

        internal static bool RemoveEndOfWord(TrieNode node, Stack<TrieNode> stack) =>
            node.IsEndOfWord && stack.All(n => n.Children.Count == 1);

        internal static void RemoveChildNode(TrieNode node, Stack<TrieNode> stack) =>
            stack.Pop().Children.Remove(node.Value);

        internal static void GetMatches(TrieNode node, List<string> result, string prefix)
        {
            if (node == null)
            {
                return;
            }

            if (node.IsEndOfWord)
            {
                result.Add(prefix);
            }

            foreach (var child in node.Children)
            {
                GetMatches(child.Value, result, prefix + child.Key);
            }
        }
    }
}
