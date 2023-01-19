using System.Collections.Generic;

namespace AutoComplete
{
    public class TrieNode
    {
        public char Value;
        public Dictionary<char, TrieNode> Children;
        public bool IsEndOfWord;

        public TrieNode(char value)
        {
            Value = value;
            Children = new Dictionary<char, TrieNode>();
        }
    }
}
