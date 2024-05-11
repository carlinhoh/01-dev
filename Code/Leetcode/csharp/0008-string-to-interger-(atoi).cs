/*
https://leetcode.com/problems/string-to-integer-atoi/submissions/1234314091/

Time: O(N)
Space: O(1)
*/

public class Solution {
    public int MyAtoi(string s) {

        int index = 0;
        int sign = 1;
        int result = 0;
        int n = s.Length;

        while (index < n && char.IsWhiteSpace(s[index])) {
            index++;
        }

        if (index < n && (s[index] == '+' || s[index] == '-')) {
            sign = s[index] == '+' ? 1 : -1;
            index++;
        }

        while (index < n && char.IsDigit(s[index])) {
            int digit = s[index++] - '0';

            if (result > (int.MaxValue - digit) / 10) {
                return sign == 1 ? int.MaxValue : int.MinValue;
            }

            result = result * 10 + digit;
        }

        return result * sign;
    }
}
