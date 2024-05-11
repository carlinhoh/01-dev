/*
https://leetcode.com/problems/valid-word-abbreviation/submissions/1237789051/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public bool ValidWordAbbreviation(string word, string abbr) {
        int i=0;
        int j=0;

        while (i < word.Length && j < abbr.Length) {
            if (word[i] == abbr[j]) {
                i++;
                j++;
                continue;
            }

            if (!char.IsDigit(abbr[j])) return false;
            if (abbr[j] == '0') return false;
            
            int num = 0;
            while (j < abbr.Length && char.IsDigit(abbr[j])) {
                num = 10 * num + abbr[j] - '0';
                j++;
            }

            i += num;
        }

        return i == word.Length && j == abbr.Length;
    }
}