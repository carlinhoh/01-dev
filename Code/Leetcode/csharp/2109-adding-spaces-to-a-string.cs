/*
https://leetcode.com/problems/adding-spaces-to-a-string/submissions/1468870255/
*/
public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        int n = s.Length;
        int totalLength = n + spaces.Length;
        char[] result = new char[totalLength]; 
        int spaceIndex = 0, resultIndex = 0;

        for (int i = 0; i < n; i++) {
            if (spaceIndex < spaces.Length && i == spaces[spaceIndex]) {
                result[resultIndex++] = ' ';
                spaceIndex++;
            }
            result[resultIndex++] = s[i];
        }

        return new string(result);
    }
}
