/*
https://leetcode.com/problems/reverse-words-in-a-string/submissions/1239322788/

Time: O(n), where n is the number of words
Space: O(n)
*/
public class Solution {
    public string ReverseWords(string s) {
        var words = s.Trim().Split(" ");
        StringBuilder sb = new();
        for(int i= words.Length-1; i>=0; i--){
            if(!string.IsNullOrWhiteSpace(words[i])){
                sb.Append(words[i]).Append(" ");
            }
        }
        return sb.ToString().Trim();
    }
}