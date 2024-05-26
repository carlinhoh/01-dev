/*
Trie + DP https://leetcode.com/problems/word-break/submissions/1268779268/

Time: O(n² + mk), where n is the length of s, m is the length of wordDict and k is the avg size of words in wordDict
Space: O(n + mk)

https://leetcode.com/problems/word-break/submissions/1268732457/

Time: O(nmk)
Space: O(n)

https://leetcode.com/problems/word-break/submissions/1236066309/

Time: O(n³mk), n is the size of 's', m the size of wordDict and k the average size of the words
Space: O(n + mk)

*/
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        TrieNode root = new TrieNode();
        foreach(string word in wordDict){
            TrieNode curr = root;
            foreach(char c in word){
                if(!curr.children.ContainsKey(c)){
                    curr.children[c] = new TrieNode();
                }
                curr = curr.children[c];
            }
            curr.Tail = true;            
        }
        bool[] dp = new bool[s.Length];
        for(int i=0;i<s.Length;i++){
            if(i == 0 || dp[i-1]){
                TrieNode curr = root;
                for(int j=i;j<s.Length;j++){
                    char c = s[j];
                    if(!curr.children.ContainsKey(c)){
                        break;
                    }
                    curr = curr.children[c];
                    if(curr.Tail){
                        dp[j] = true;
                    }
                }
            }
        }
        return dp[s.Length - 1];      
    }
    public class TrieNode{
        public bool Tail { get; set;}
        public Dictionary<char, TrieNode> children;
        public TrieNode(){
            children = new();
        }
    }
}
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        bool[] dp = new bool[s.Length];
        for(int i=0;i<s.Length;i++){
            foreach(string word in wordDict){
                if(i < word.Length - 1){
                    continue;
                }
                if(i == word.Length - 1 || dp[i - word.Length]){
                    if(s.Substring(i - word.Length + 1, word.Length) == word){
                        dp[i] = true;
                        break;
                    }
                }
            }
        }
        return dp[s.Length - 1];
    }
}

public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        int n = s.Length;
        int maxWordLength = 0;
        HashSet<string> seen = new HashSet<string>(wordDict);

        foreach (var word in wordDict) {
            maxWordLength = Math.Max(maxWordLength, word.Length);
        }
        
        bool[] dp = new bool[n + 1];
        dp[0] = true;

        for (int i = 1; i <= n; i++) {
            for (int j = Math.Max(0, i - maxWordLength); j < i; j++) {
                if (dp[j] && seen.Contains(s[j..i])) {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n];
    }
}
