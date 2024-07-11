/*
https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses/submissions/1318073528/]

Time: O(n)
Space: O(n)
*/

public class Solution {
    public string ReverseParentheses(string s) {
        int n = s.Length;
        Stack<int> openParenthesesIndices = new Stack<int>();
        int[] pair = new int[n];

        for (int i = 0; i < n; ++i) {
            if (s[i] == '(') {
                openParenthesesIndices.Push(i);
            }
            if (s[i] == ')') {
                int j = openParenthesesIndices.Pop();
                pair[i] = j;
                pair[j] = i;
            }
        }

        StringBuilder result = new StringBuilder();
        for (int currIndex = 0, direction = 1; currIndex < n; currIndex += direction) {
            if (s[currIndex] == '(' || s[currIndex] == ')') {
                currIndex = pair[currIndex];
                direction = -direction;
            } else {
                result.Append(s[currIndex]);
            }
        }

        return result.ToString();
    }
}
