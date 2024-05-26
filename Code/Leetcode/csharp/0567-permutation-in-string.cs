/*
sliding window https://leetcode.com/problems/permutation-in-string/submissions/1268850248/

Time: O(l1 + (l2 - l1)), where l1 is the size of s1 and l2 the size of s2
Space: O(1)
*/
public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int s1Length = s1.Length;
        int s2Length = s2.Length;

        // If s1 is longer than s2, it's impossible for any permutation of s1 to be in s2.
        if (s1Length > s2Length)
            return false;

        // Arrays to store the character counts from 'a' to 'z' (26 characters).
        int[] s1CharCount = new int[26];
        int[] s2CharCount = new int[26];

        // Counting the frequency of each character in s1 and the first s1.Length characters of s2.
        for (int i = 0; i < s1Length; i++) {
            s1CharCount[s1[i] - 'a']++;
            s2CharCount[s2[i] - 'a']++;
        }

        // Counter to check how many characters have the same frequency in s1CharCount and s2CharCount.
        int matchCount = 0;
        for (int i = 0; i < 26; i++) {
            if (s1CharCount[i] == s2CharCount[i])
                matchCount++;
        }

        // Sliding the window over s2.
        for (int i = 0; i < s2Length - s1Length; i++) {
            // Index of the character entering the window.
            int right = s2[i + s1Length] - 'a';
            // Index of the character leaving the window.
            int left = s2[i] - 'a';
            
            // If all 26 characters have matching frequencies, we've found a permutation.
            if (matchCount == 26)
                return true;

            // Update the frequency of the character entering the window.
            s2CharCount[right]++;
            if (s2CharCount[right] == s1CharCount[right]) {
                matchCount++;
            } else if (s2CharCount[right] == s1CharCount[right] + 1) {
                matchCount--;
            }

            // Update the frequency of the character leaving the window.
            s2CharCount[left]--;
            if (s2CharCount[left] == s1CharCount[left]) {
                matchCount++;
            } else if (s2CharCount[left] == s1CharCount[left] - 1) {
                matchCount--;
            }
        }

        // Final check after the loop
        return matchCount == 26;
    }
}
