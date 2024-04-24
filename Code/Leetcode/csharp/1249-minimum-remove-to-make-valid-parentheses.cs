/*
https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/submissions/1241038682/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public string MinRemoveToMakeValid(string s) {
        StringBuilder sb = new();
        int open = 0;
        int close = s.Count(x => x == ')');

        for(int i=0;i<s.Length;i++){
            if(s[i] == '(') {
                if(close>open){
                    sb.Append(s[i]);
                    open++;
                }
            }
            else if(s[i] == ')'){
                if(open > 0){
                    sb.Append(s[i]);
                    open--;
                }
                close--;
            }
            else{
                sb.Append(s[i]);
            }
        }
        
        return sb.ToString();
    
    }
}