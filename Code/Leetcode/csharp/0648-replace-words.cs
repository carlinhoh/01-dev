/*
https://leetcode.com/problems/replace-words/submissions/1280968479

Time: O(n * k + m * k), where n is the size of the dictionary, k the avg length of the words and m the size of the sentence
Space: O(n * k)
*/
public class Solution {
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        Trie TrieWords = new();

        foreach (string word in dictionary) {
            TrieWords.Insert(word);
        }

        string[] words = sentence.Split(' ');
        StringBuilder result = new();
        StringBuilder prefix = new StringBuilder();

        foreach (string word in words) {
            Trie.TrieNode node = TrieWords.head;
            prefix.Clear();
            bool found = false;

            foreach (char c in word) {
                if (node[c] == null) {
                    break;
                }
                prefix.Append(c);
                node = node[c];
                if (node.IsWordEnd) {
                    result.Append(prefix.ToString()).Append(" ");
                    found = true;
                    break;
                }
            }

            if (!found) {
                result.Append(word).Append(" ");
            }
        }

        if (result.Length > 0) {
            result.Length--;
        }

        return result.ToString();
    }

    public class Trie {
        public TrieNode head;

        public Trie() {
            head = new TrieNode();
        }

        public void Insert(string word) {
            TrieNode current = head;
            foreach (char c in word) {
                if (current[c] == null) {
                    current[c] = new TrieNode();
                }
                current = current[c];
            }
            current.IsWordEnd = true;
        }

        public class TrieNode {
            public TrieNode[] children = new TrieNode[26];

            internal TrieNode this[char c] {
                get => children[c - 'a'];
                set => children[c - 'a'] = value;
            }

            public bool IsWordEnd { get; set; } = false;
        }
    }
}
