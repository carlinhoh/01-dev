/*
https://leetcode.com/problems/merge-strings-alternately/submissions/1216496530/

Time: O(N)
Space: O(1)
*/
public class Solution {
    public string MergeAlternately(string word1, string word2) {

        int size = Math.Max(word1.Length, word2.Length);
        StringBuilder mergedWords = new();

        for(int i=0;i<size;i++){
            if(i<word1.Length){
                mergedWords.Append(word1[i]);
            }
            if(i<word2.Length){
                mergedWords.Append(word2[i]);
            }
        }

        return mergedWords.ToString();
    }
}