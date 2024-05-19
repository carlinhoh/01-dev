/*
DFA https://leetcode.com/problems/valid-number/submissions/1262564389/

Time: O(n)
Space: O(1)

Rules https://leetcode.com/problems/valid-number/submissions/1262564797/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public bool IsNumber(string s) {
        var dfa = new Dictionary<string, int>[] {
            new Dictionary<string, int> {
                { "digit", 1 }, { "sign", 2 }, { "dot", 3 }
            },
            new Dictionary<string, int> {
                { "digit", 1 }, { "dot", 4 }, { "exponent", 5 }
            },
            new Dictionary<string, int> { { "digit", 1 }, { "dot", 3 } },
            new Dictionary<string, int> { { "digit", 4 } },
            new Dictionary<string, int> { { "digit", 4 }, { "exponent", 5 } },
            new Dictionary<string, int> { { "sign", 6 }, { "digit", 7 } },
            new Dictionary<string, int> { { "digit", 7 } },
            new Dictionary<string, int> { { "digit", 7 } }
        };
        int currentState = 0;
        string group;

        foreach (char curr in s) {
            if (Char.IsDigit(curr)) {
                group = "digit";
            } else if (curr == '+' || curr == '-') {
                group = "sign";
            } else if (curr == 'e' || curr == 'E') {
                group = "exponent";
            } else if (curr == '.') {
                group = "dot";
            } else {
                return false;
            }
            if (!dfa[currentState].ContainsKey(group)) {
                return false;
            }
            currentState = dfa[currentState][group];
        }
        return currentState == 1 || currentState == 4 || currentState == 7;
    }
}

public class Solution {
    public bool IsNumber(string s) {
        bool seenDigit = false;
        bool seenExponent = false;
        bool seenDot = false;
        for (int i = 0; i < s.Length; i++) {
            char curr = s[i];
            if (Char.IsDigit(curr)) {
                seenDigit = true;
            } else if (curr == '+' || curr == '-') {
                if (i > 0 && s[i - 1] != 'e' && s[i - 1] != 'E') {
                    return false;
                }
            } else if (curr == 'e' || curr == 'E') {
                if (seenExponent || !seenDigit) {
                    return false;
                }

                seenExponent = true;
                seenDigit = false;
            } else if (curr == '.') {
                if (seenDot || seenExponent) {
                    return false;
                }

                seenDot = true;
            } else {
                return false;
            }
        }

        return seenDigit;
    }
}