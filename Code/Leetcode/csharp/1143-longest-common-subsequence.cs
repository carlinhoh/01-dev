/*
https://leetcode.com/problems/longest-common-subsequence/submissions/1262664613/

Time: O(n*m)
Space: O(min(n,m))
*/
public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        if (text2.Length < text1.Length) {
            string temp = text1;
            text1 = text2;
            text2 = temp;
        }

        int[] previous = new int[text1.Length + 1];
        int[] current = new int[text1.Length + 1];

        for (int col = text2.Length - 1; col >= 0; col--) {
            for (int row = text1.Length - 1; row >= 0; row--) {
                if (text1[row] == text2[col]) {
                    current[row] = 1 + previous[row + 1];
                } else {
                    current[row] = Math.Max(previous[row], current[row + 1]);
                }
            }
            int[] temp = previous;
            previous = current;
            current = temp;
        }

        return previous[0];
    }
}
