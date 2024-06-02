/*
https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/submissions/1275760852/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int MaxDepth(string s) {
        int max = 0;
        int balance = 0;
        for(int i=0;i<s.Length;i++){
            if(s[i] == '('){
                max = Math.Max(++balance, max);
            }
            else if(s[i] == ')'){
                balance--;
            }
        }
        return max;
    }
}