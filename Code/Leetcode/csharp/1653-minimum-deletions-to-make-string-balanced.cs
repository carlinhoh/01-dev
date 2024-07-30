/*
https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/submissions/1338959199/

Time: O(n)
Space: O(1)

*/
public class Solution {
    public int MinimumDeletions(string s) {
       int n = s.Length;
       int minDel = 0;
       int bCount = 0;

        for (int i = 0; i < n; i++) {
            if (s[i] == 'b') {
                bCount++;
            } else {
                minDel = Math.Min(minDel + 1, bCount);
            }
        }

        return minDel;  
    }
}