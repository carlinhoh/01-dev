/*
https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/submissions/1275624587/

Time: O(n)
Space: O(k)
*/

public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        if(k>s.Length){
            return s.Length;
        }
        if(k==0){
            return 0;
        }
        int max = 0;
        Dictionary<char, int> freq = new();
        for(int right = 0;right<s.Length; right++){
            freq.TryAdd(s[right], 0);
            freq[s[right]]++;
            if(freq.Count <= k){
                max++;
            }
            else{
                if(freq[s[right-max]] == 1){
                    freq.Remove(s[right-max]);
                }
                else{
                    freq[s[right-max]]--;
                }
            }
        }
        return max;
    }
}