/*
https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string-ii/submissions/1271879594/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public string RemoveDuplicates(string s, int k) {
        int j = 0;
        Stack<int> counts = new Stack<int>();

        char[] chars = s.ToCharArray();
        
        for (int i = 0; i < s.Length; ++i, ++j) {
            chars[j] = chars[i];
            if (j == 0 || chars[j] != chars[j - 1]) {
                counts.Push(1);
            } else {
                int newCount = counts.Pop() + 1;
                if (newCount == k) {
                    j -= k;
                } else {
                    counts.Push(newCount);
                }
            }
        }
        
        return new string(chars, 0, j);
    }
}
