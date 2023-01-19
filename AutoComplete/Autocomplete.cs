using System.Collections.Generic;

namespace AutoComplete
{
    public class Autocomplete : Trie
    {
        public List<string> GetMatches(string prefix)
        {
            var node = GetEndNode(prefix);
            var result = new List<string>();
            Helpers.GetMatches(node, result, prefix);
            return result;
        }

        private TrieNode GetEndNode(string prefix)
        {
            var node = Root;
            TrieNode childNode;
            foreach (var c in prefix)
            {
                node = node.Children.TryGetValue(c, out childNode) ? childNode : null;
                if (node == null) break;
            }
            return node;
        }
    }
}
