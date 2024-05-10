/*
https://leetcode.com/problems/design-add-and-search-words-data-structure/submissions/1254608053/

Time: O(N x M^26), Where N is the number of words and M is the largest word
Space: O(1) for the search of "well-defined" words without dots, and up to O(M) for the "undefined" words, to keep the recursion stack.
*/
public class WordDictionary {

    private TrieNode head;

    public WordDictionary() {
        head = new TrieNode();
    }
    
    public void AddWord(string word) {
        var current = head;
        foreach(char c in word) {
            if(current[c] == null) {
                current[c] = new TrieNode();
            }
            current = current[c];
        }
        current.IsWordEnd = true;
    }
    
    public bool Search(string word) {
        return Search(word, head, 0);
    }

    private bool Search(string word, TrieNode node, int index) {
        if (index == word.Length) {
            return node.IsWordEnd;
        }
        char currentChar = word[index];
        if (currentChar == '.') {
            for (int i = 0; i < 26; i++) {
                if (node.children[i] != null && Search(word, node.children[i], index + 1)) {
                    return true;
                }
            }
            return false;
        } else {
            TrieNode child = node[currentChar];
            if (child != null) {
                return Search(word, child, index + 1);
            }
        }
        return false;
    }   

    public class TrieNode{
        public TrieNode[] children = new TrieNode[26];

        internal TrieNode this[char c] { 
            get => children[c-'a']; 
            set => children[c-'a'] = value; 
        }

        public bool IsWordEnd { get; set; } = false;
    }
}