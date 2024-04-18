/*
https://leetcode.com/problems/word-break/submissions/1236066309/

Time: O(n³mk), n is the size of 's', m the size of wordDict and k the average size of the words
Space: O(n + mk)

*/

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
