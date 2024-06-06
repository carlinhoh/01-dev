/*
https://leetcode.com/problems/check-if-two-string-arrays-are-equivalent/submissions/1278411666/

Time: O(n * k)
Space: O(1)
*/
public class Solution {
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) {
        int p1 = 0;
        int p2 = 0;
        
        int c1 = 0;
        int c2 = 0;
        
        while(p1 < word1.Length && p2 < word2.Length){
            if(word1[p1][c1++] != word2[p2][c2++]){
                return false;
            }
            if(c1 == word1[p1].Length){
                p1++;
                c1 = 0;
            }
            if(c2 == word2[p2].Length){
                p2++;
                c2 = 0;
            }
        }
        return p1 == word1.Length && p2 == word2.Length;
    }
}