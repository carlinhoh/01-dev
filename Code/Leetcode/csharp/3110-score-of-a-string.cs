/*
https://leetcode.com/problems/score-of-a-string/submissions/1305195839/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int ScoreOfString(string s) {
        int score = 0;
        
        for(int i=1;i<s.Length;i++){
            score += Math.Abs(s[i] - s[i - 1]);
        }

        return score;
    }
}