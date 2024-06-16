/*
https://leetcode.com/problems/repeated-substring-pattern/submissions/1289418663/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        StringBuilder sb = new(s);
        sb.Append(s);
        sb.Remove(0,1);
        sb.Remove(sb.Length - 1, 1); 

        if(sb.ToString().Contains(s)){
            return true;
        }

        return false;
    }
}