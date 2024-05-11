/*
https://leetcode.com/problems/generate-parentheses/submissions/1255449006/

Time: O((4^n)/sqrt(n))
Space: O(n)
*/
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        List<string> res = new List<string>();
        Generate(res, new char[2 * n], 0, 0, 0, n);
        return res;
    }

    private void Generate(List<string> res, char[] current, int pos, int open, int close, int n) {
        if (pos == current.Length) {
            res.Add(new string(current));
            return;
        }

        if (open < n) {
            current[pos] = '(';
            Generate(res, current, pos + 1, open + 1, close, n);
        }
        if (close < open) {
            current[pos] = ')';
            Generate(res, current, pos + 1, open, close + 1, n);
        }
    }
}