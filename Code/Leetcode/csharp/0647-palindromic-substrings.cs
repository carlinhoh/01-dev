/*
https://leetcode.com/problems/palindromic-substrings/submissions/1236036744/

Time: O(n²)
Space: O(1)
*/

public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length;
        int count = 0; 
        if (n == 0) return 0;

        int CountPalindromesAroundCenter(int left, int right) {
            int localCount = 0;
            while (left >= 0 && right < n && s[left] == s[right]) {
                localCount++;  
                left--;  
                right++; 
            }
            return localCount;
        }

        for (int i = 0; i < n; i++) {
            count += CountPalindromesAroundCenter(i, i);
            count += CountPalindromesAroundCenter(i, i + 1);
        }

        return count; 
    }
}
