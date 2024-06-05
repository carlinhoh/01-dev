/*
https://leetcode.com/problems/find-common-characters/submissions/1277951548/

Time: O(n*k)
Space: O(1)
*/
public class Solution {
    public IList<string> CommonChars(string[] words) {
        int[] freq = new int[26];

        for(int i=0;i<words[0].Length;i++){
            freq[words[0][i] - 'a']++;
        }

        List<string> result = new();

        for(int i=1;i<words.Length;i++){
            int[] freq2 = new int[26];
            for (int j = 0; j < words[i].Length; j++) {
                freq2[words[i][j] - 'a']++;
            }
            for (int k = 0; k < 26; k++) {
                freq[k] = Math.Min(freq[k], freq2[k]);
            }
        }
        for (int i = 0; i < 26; i++) {
            if (freq[i] > 0) {
                char c = (char) (i + 'a');
                for (int j = 0; j < freq[i]; j++) {
                    result.Add(c.ToString());
                }
            }
        }
        return result;
    }
}