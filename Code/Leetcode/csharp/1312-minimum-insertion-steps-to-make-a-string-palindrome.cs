/*
https://leetcode.com/problems/minimum-insertion-steps-to-make-a-string-palindrome/submissions/1274577610/

Time: O(n²)
Space: O(n)

https://leetcode.com/problems/minimum-insertion-steps-to-make-a-string-palindrome/submissions/1274575147/

Time: O(n²)
Space: O(n)
*/
public class Solution {
    public int MinInsertions(string s) {

        int n = s.Length;
        int[] dp = new int[n];

        for (int i = n - 2; i >= 0; i--)
        {
            int prev = 0; 
            
            for (int j = i + 1; j < n; j++)
            {
                int temp = dp[j]; 
                if (s[i] == s[j])
                {
                    dp[j] = prev; 
                }
                else
                {
                    dp[j] = 1 + Math.Min(dp[j], dp[j - 1]);
                }
                
                prev = temp;
            }
        }
        return dp[n-1];


    }
}

public class Solution {
    public int MinInsertions(string s) {
        int n = s.Length;
        string sReverse = new string(s.Reverse().ToArray());

        return n - LCS(s, sReverse);
    }
    private int LCS(string s1, string s2){
        int n = s1.Length;
        int[] previous = new int[n + 1];
        int[] current = new int[n + 1];

        for (int i = n - 1; i >= 0; i--) {
            for (int j = n - 1; j >= 0; j--) {
                if (s1[i] == s2[j]) {
                    current[j] = 1 + previous[j + 1];
                } else {
                    current[j] = Math.Max(previous[j], current[j + 1]);
                }
            }
            int[] temp = previous;
            previous = current;
            current = temp;
        }

        return previous[0];
    }
}