/*
https://leetcode.com/problems/decode-ways/submissions/1236127349/

Time:O(n)
Space:O(1)
*/
public class Solution {
    public int NumDecodings(string s) {
        if (s[0] == '0') {
            return 0;
        }

        int n = s.Length; 
        int twoBack = 1;  
        int oneBack = 1;  

        for (int i = 1; i < n; i++) {
            int current = 0; 

            if (s[i] != '0') {
                current = oneBack;
            }

            int twoDigit = (s[i - 1] - '0') * 10 + (s[i] - '0');

            if (twoDigit >= 10 && twoDigit <= 26) {
                current += twoBack; 
            }
            twoBack = oneBack; 
            oneBack = current; 
        }
        return oneBack;
    }
}

