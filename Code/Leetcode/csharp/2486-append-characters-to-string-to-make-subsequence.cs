/*
https://leetcode.com/problems/append-characters-to-string-to-make-subsequence/submissions/1255450821/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int AppendCharacters(string s, string t) {

        int tIndex = 0;

        for(int sIndex=0;sIndex<s.Length && tIndex<t.Length;sIndex++){
            if(t[tIndex] == s[sIndex]){
                tIndex++;
            }
        }

        return t.Length - tIndex;
    }
}