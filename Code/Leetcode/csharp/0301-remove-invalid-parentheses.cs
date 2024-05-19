/*
https://leetcode.com/problems/remove-invalid-parentheses/submissions/1262591573/

Time: O(2^n)
Space: O(n)
*/

public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        var balance = GetBalance(s);

        if (s.Length == balance.opened + balance.closed) {
            return new List<string>() { "" };
        }

        HashSet<string> result = new HashSet<string>();
        GetBalancedOptions(s, 0, balance.opened, balance.closed, 0, new StringBuilder(), result, s.Length - (balance.opened + balance.closed));
        return new List<string>(result);
    }

    private void GetBalancedOptions(string s, int index, int opened, int closed, int balance, StringBuilder current, HashSet<string> result, int targetLength) {
        if (current.Length == targetLength) {
            if (balance == 0) {
                result.Add(current.ToString());
            }
            return;
        }

        if (index == s.Length) {
            return;
        }

        char ch = s[index];
        if (ch == '(' && opened > 0) {
            GetBalancedOptions(s, index + 1, opened - 1, closed, balance, current, result, targetLength); // Skip current '('
        }
        if (ch == ')' && closed > 0) {
            GetBalancedOptions(s, index + 1, opened, closed - 1, balance, current, result, targetLength); // Skip current ')'
        }

        current.Append(ch);
        if (ch == '(') {
            GetBalancedOptions(s, index + 1, opened, closed, balance + 1, current, result, targetLength); // Include current '('
        } else if (ch == ')') {
            if (balance > 0) {
                GetBalancedOptions(s, index + 1, opened, closed, balance - 1, current, result, targetLength); // Include current ')'
            }
        } else {
            GetBalancedOptions(s, index + 1, opened, closed, balance, current, result, targetLength); // Include current non-parenthesis character
        }
        current.Length--; // Backtrack
    }

    public (int opened, int closed) GetBalance(string s) {
        int opened = 0;
        int closed = 0;
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                opened++;
            } else if (s[i] == ')') {
                if (opened > 0) {
                    opened--;
                } else {
                    closed++;
                }
            }
        }
        return (opened, closed);
    }
}