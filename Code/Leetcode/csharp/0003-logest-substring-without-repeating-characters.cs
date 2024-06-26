/*
#blind-75
#neetcode-150
Dictionary https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/1156837867/
HashSet https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/1272799758/
Time:O(N)
Space:O(K) Where K is defined by the number of distinct characters, in the case of alphabet: 26 the solution is O(1).
*/
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        HashSet<char> seen = new();
        int left = 0;
        int max = 0;
        for(int right=0;right<s.Length;right++){
            while(seen.Contains(s[right])){
                seen.Remove(s[left++]);
            }
            seen.Add(s[right]);
            max = Math.Max(seen.Count, max);
        }

        return max;
    }
}

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int left = 0;
        int maxLength = 0;

        Dictionary<char, int> seen = new();

        for(int right = 0;right<s.Length;right++){
            if(seen.ContainsKey(s[right])){
                left = Math.Max(left, seen[s[right]] + 1);
                seen.Remove(s[right]);
            }
            seen.TryAdd(s[right], right);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}