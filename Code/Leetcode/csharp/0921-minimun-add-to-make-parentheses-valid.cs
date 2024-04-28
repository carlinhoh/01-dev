/*
https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/submissions/1244493379/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public int MinAddToMakeValid(string s) {
        if(string.IsNullOrEmpty(s)) return 0;

        int close = 0;
        int open = 0;

        foreach(char parenthesis in s){
            if(parenthesis == '('){
                open++;
            }
            else{
                if(open == 0){
                    close++;
                }
                else{
                    open--;
                }
            }
        }

        return  open + close;
    }
}