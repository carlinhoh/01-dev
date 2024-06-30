/*
https://leetcode.com/problems/reverse-string/submissions/1305191297/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public void ReverseString(char[] s) {
        for(int i=0;i<s.Length/2;i++){
            Swap(s, i, s.Length - 1 - i);
        }
    }

    public void Swap(char[] s, int x, int y){
        var temp = s[x];
        s[x] = s[y];
        s[y] = temp;
    }
}