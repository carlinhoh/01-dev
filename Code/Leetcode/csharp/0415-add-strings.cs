/*
https://leetcode.com/problems/add-strings/submissions/1275441382/

Time: O(Max(num1, num2))
Space: O(Max(num1, num2))
*/
public class Solution {
    public string AddStrings(string num1, string num2) {
        StringBuilder sb = new();
        int carry = 0;
        int p1 = num1.Length - 1;
        int p2 = num2.Length - 1;

        while (p1 >= 0 || p2 >= 0 || carry != 0) {
            int x1 = p1 >= 0 ? num1[p1--] - '0' : 0;
            int x2 = p2 >= 0 ? num2[p2--] - '0' : 0;

            int sum = x1 + x2 + carry;
            carry = sum / 10;
            sb.Append(sum % 10);
        }

        return new string(sb.ToString().Reverse().ToArray());
    }
}
