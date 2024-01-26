/*
#blind-75
#neetcode-150
https://leetcode.com/problems/valid-parentheses/submissions/1157824002/

Time:O(N)
Space:O(N)
*/
public class Solution {
    public bool IsValid(string s) {
        
        Stack<char> brackets = new();
        foreach(var c in s){
            if(c == '('){
                brackets.Push(')');
            }
            else if(c == '{'){
                brackets.Push('}');
            }
            else if(c == '['){
                brackets.Push(']');
            }
            else{
                if(brackets.Count == 0 || brackets.Pop() !=  c){
                    return false;
                }
            }

        }
        return brackets.Count==0;
    }
}