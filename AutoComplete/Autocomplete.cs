using System.Collections.Generic;

namespace AutoComplete
{
    public class Autocomplete : Trie
    {
        public List<string> GetMatches(string prefix)
        {
            var currentNode = Root;
            var result = new List<string>();
            foreach (var c in prefix)
            {
                if (!currentNode.Children.ContainsKey(c))
                {
                    return result;
                }

                currentNode = currentNode.Children[c];
            }
            GetMatches(currentNode, result, prefix);
            return result;
        }

        private void GetMatches(TrieNode node, List<string> result, string prefix)
        {
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
