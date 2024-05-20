/*
https://leetcode.com/problems/valid-palindrome-iii/submissions/1262662821/

Time: O(n²)
Space: O(n)

Without reverse https://leetcode.com/problems/valid-palindrome-iii/submissions/1262666481/

Time: O(n²)
Space: O(n)
*/
public class Solution {
    public bool IsValidPalindrome(string s, int k) {
        if(s.Length == k) return true;

        int[] previous = new int[s.Length + 1];
        int[] current = new int[s.Length + 1];

        for(int i = s.Length - 1; i >= 0; i--) {
            for(int j = 0; j < s.Length; j++) {
                if(s[i] == s[j]) {
                    current[j + 1] = previous[j] + 1;
                } else {
                    current[j + 1] = Math.Max(previous[j + 1], current[j]);
                }
            }

            int[] temp = previous;
            previous = current;
            current = temp;
        }

        return (s.Length - k) <= previous[s.Length];
    }
}

public class Solution {
    public bool IsValidPalindrome(string s, int k) {
        if(s.Length == k) return true;

        string reversedS = new string(s.Reverse().ToArray());

        int[] previous = new int[s.Length + 1];
        int[] current = new int[s.Length + 1];

        for(int col = s.Length - 1; col >= 0; col--){
            for(int row = s.Length -1; row >= 0;row--){
                if(s[row] == reversedS[col]){
                    current[row] = 1 + previous[row + 1];
                }
                else{
                    current[row] = Math.Max(previous[row], current[row + 1]);
                }
            }

            int[] temp = previous;
            previous = current;
            current = temp;
        }

        return (s.Length - k) <= previous[0];
    }
}