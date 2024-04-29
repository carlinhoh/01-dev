/*
https://leetcode.com/problems/ransom-note/submissions/1245314875/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        int[] magazineChars = new int[128];

        foreach(var c in magazine){
            magazineChars[c]++;
        }

        foreach(var c in ransomNote){
            if(magazineChars[c] == 0){
                return false;
            }
            magazineChars[c]--;
        }
        
        return true;
    }
}