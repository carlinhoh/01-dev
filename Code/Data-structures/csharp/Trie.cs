public class Trie
{
    private TrieNode head;

    public Trie()
    {
        head = new TrieNode();
    }

    public void Insert(string word)
    {
        var current = head;
        foreach (char c in word)
        {
            if (current[c] == null)
            {
                current[c] = new TrieNode();
            }
            current = current[c];
        }
        current.IsWordEnd = true;
    }

    public bool StartsWith(string prefix)
    {
        return ToTail(prefix) != null;
    }

    public bool Search(string word)
    {
        var node = ToTail(word);
        return node != null && node.IsWordEnd;
    }

    public bool Search(string word, char wildCard)
    {
        return Search(word, head, 0, wildCard);
    }

    private TrieNode ToTail(string prefix)
    {
        var current = head;
        foreach (char c in prefix)
        {
            current = current[c];
            if (current == null)
                return null;
        }
        return current;
    }

    private bool Search(string word, TrieNode node, int index, char wildCard)
    {
        if (index == word.Length)
        {
            return node.IsWordEnd;
        }

        char currentChar = word[index];
        if (currentChar == wildCard)
        {
            for (int i = 0; i < 26; i++)
            {
                if (node.children[i] != null && Search(word, node.children[i], index + 1, wildCard))
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            TrieNode child = node[currentChar];
            if (child != null)
            {
                return Search(word, child, index + 1, wildCard);
            }
        }
        return false;
    }

    public class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];

        internal TrieNode this[char c]
        {
            get => children[c - 'a'];
            set => children[c - 'a'] = value;
        }

        public bool IsWordEnd { get; set; } = false;
    }
}
