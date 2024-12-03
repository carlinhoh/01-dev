/*
Two Pointers
https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/submissions/1468845514/
Time: O(n), where n is the length of the sentence. Each character is visited once as we traverse the sentence directly.
Space: O(1), as no additional data structures are used apart from a few pointers and counters.

Two Pointers with Split
https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/submissions/1468837191/
Time: O(n + km), where n is the length of the sentence, k is the number of words, and m is the size of the prefix. 
      Splitting the sentence takes O(n), and verifying prefixes takes O(km) in the worst case.
Space: O(n), for the array of words created by the split.

StringBuilder
https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/submissions/1468859823/
Time: O(km), where k is the number of words and m is the average length of the words.
      Each word is processed character by character to build the prefixes.
Space: O(m), for the StringBuilder used to construct prefixes.

StringBuilder + Dictionary
https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/submissions/1468829524/
Time: O(km), where k is the number of words and m is the average length of the words. 
      Generating prefixes and adding them to the dictionary involves iterating through each character of each word.
Space: O(km), for the dictionary storing all prefixes and their indices.
Trie
https://leetcode.com/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/submissions/1468824767/
Time: O(km), where k is the number of words and m is the average length of the words.
      Insertion and prefix search operations in the Trie involve processing each character of the words.
Space: O(km), as the Trie structure requires storing all characters in the words.
*/

public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        if(searchWord.Length > sentence.Length || sentence.Length == 0  || searchWord.Length == 0){
            return -1;
        }
        int wordIndex = 1; 
        int i = 0;

        while (i < sentence.Length){
            int j=0;
            while (i < sentence.Length && j < searchWord.Length && sentence[i] == searchWord[j]) {
                i++;
                j++;
            }
            if(j == searchWord.Length){
                return wordIndex;
            }
            while (i < sentence.Length && sentence[i] != ' ') {
                i++;
            }
            i++;
            wordIndex++;
        }

        return -1;
    }
}

public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        if(searchWord.Length > sentence.Length || sentence.Length == 0  || searchWord.Length == 0){
            return -1;
        }
        int j = 0;
        var sentences = sentence.Split(' ');
        for(int i=0;i<sentences.Length && j<searchWord.Length;i++){
            while(j < sentences[i].Length && sentences[i][j] == searchWord[j]){
                j++;
                if(j == searchWord.Length){
                    return i + 1;
                }
            }
            j=0;
        }

        return -1;
    }
}
public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        StringBuilder sb = new();
        var sentences = sentence.Split(' ');
        for(int i=0;i<sentences.Length;i++){
            foreach(var c in sentences[i]){
                if (sb.Length >= searchWord.Length || c != searchWord[sb.Length]){
                    break;
                }
                sb.Append(c);
                var currPrefix = sb.ToString();
                if(currPrefix == searchWord){
                    return i + 1;
                }
            }
            sb.Clear();
        }
        return -1;
    }
}

public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        StringBuilder sb = new();
        var sentences = sentence.Split(' ');
        Dictionary<string, int> indexes = new();
        for(int i=0;i<sentences.Length;i++){
            foreach(var c in sentences[i]){
                if (sb.Length >= searchWord.Length || c != searchWord[sb.Length]){
                    break;
                }
                sb.Append(c);
                var currPrefix = sb.ToString();
                if(!indexes.ContainsKey(currPrefix)){
                    indexes.Add(currPrefix, i+1);
                }
            }
            sb.Clear();
        }
        if(indexes.ContainsKey(searchWord)){
            return indexes[searchWord];
        }
        return -1;
    }
}

public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        Trie trie = new Trie();
        var sentences = sentence.Split(' ');
        for(int i=0;i<sentences.Length;i++){
            trie.Insert(sentences[i], i);
        }

        return trie.GetPrefixIndex(searchWord);
    }

    public class TrieNode{
        public TrieNode[] children = new TrieNode[26];
        public int cIndex = int.MaxValue;
        internal TrieNode this[char c]
        {
            get => children[c - 'a'];
            set => children[c - 'a'] = value;
        }

    }

    public class Trie{
        private TrieNode head; 
        public Trie(){
            head = new();
        }
        
        public void Insert(string word, int index){
            var current = head;
            foreach(var c in word){
                if(current[c] == null){
                    current[c] = new TrieNode();
                    current[c].cIndex = Math.Min(index + 1, current[c].cIndex);
                }
                current = current[c];
            }
        }

        public int GetPrefixIndex(string prefix){
            var current = head;
            foreach (char c in prefix){
                current = current[c];
                if (current == null)
                    return -1;
            }
            return current.cIndex;
        }    
    }
}