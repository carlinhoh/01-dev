/*
Trie https://leetcode.com/problems/word-break-ii/submissions/1268821776/

Time: O(2^n)
Space: O(2^n)

Backtracking https://leetcode.com/problems/word-break-ii/submissions/1268810252/

Time: O(2^n)
Space: O(2^n)

*/
public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        TrieNode root = new TrieNode();
        foreach(string word in wordDict){
            TrieNode curr = root;
            foreach(char c in word){
                if(!curr.Children.ContainsKey(c)){
                    curr.Children[c] = new TrieNode();
                }
                curr = curr.Children[c];
            }
            curr.IsEndOfWord = true;
        }
        Dictionary<int, List<string>> dp = new();
        for(int startIdx=s.Length - 1;startIdx>=0;startIdx--){
            List<string> validSentences = new();
            TrieNode curr = root;
            for(int endIdx = startIdx; endIdx < s.Length; endIdx++){
                char c = s[endIdx];
                if(!curr.Children.ContainsKey(c)){
                    break;
                }
                curr = curr.Children[c];
                if(curr.IsEndOfWord){
                    string currString = s.Substring(startIdx, endIdx - startIdx + 1);
                    if(endIdx == s.Length - 1){
                        validSentences.Add(currString);
                    }
                    else{
                        List<string> sentencesFromNextIndex = dp[endIdx + 1];
                        if(sentencesFromNextIndex != null){
                            foreach(string sentence in sentencesFromNextIndex){
                                validSentences.Add(currString + " " + sentence);
                            }
                        }
                    }
                }
            }
            dp.Add(startIdx, validSentences);
        }

        return dp[0];
    }

    public class TrieNode{
        public Dictionary<char, TrieNode> Children;
        public bool IsEndOfWord;

        public TrieNode(){
            Children = new();
            IsEndOfWord = false;
        }
    }
}
public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        // Convert wordDict to a HashSet for O(1) lookups
        HashSet<string> wordSet = new HashSet<string>(wordDict);
        List<string> results = new List<string>();
        // Start the backtracking process
        Backtrack(s, wordSet, new StringBuilder(), results, 0);
        return results;
    }

    private void Backtrack(
        string s,
        HashSet<string> wordSet,
        StringBuilder currentSentence,
        List<string> results,
        int startIndex
    ) {
        // If we've reached the end of the string, add the current sentence to results
        if (startIndex == s.Length) {
            results.Add(currentSentence.ToString().Trim());
            return;
        }

        // Iterate over possible end indices
        for (int endIndex = startIndex + 1; endIndex <= s.Length; endIndex++) {
            string word = s.Substring(startIndex, endIndex - startIndex);
            // If the word is in the set, proceed with backtracking
            if (wordSet.Contains(word)) {
                int currentLength = currentSentence.Length;
                currentSentence.Append(word).Append(" ");
                // Recursively call Backtrack with the new end index
                Backtrack(s, wordSet, currentSentence, results, endIndex);
                // Reset currentSentence to its original length
                currentSentence.Length = currentLength;
            }
        }
    }
}

