/*
https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/submissions/1275623308/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        Dictionary<char, int> freq = new();
        int maxLength = 0;
        for(int right = 0;right<s.Length;right++){
            freq.TryAdd(s[right], 0);
            freq[s[right]]++;
            if(freq.Count <= 2){
                maxLength++;
            }
            else{
                char leftCharWindow = s[right-maxLength];
                if(freq[leftCharWindow] == 1){
                    freq.Remove(leftCharWindow);
                }
                else{
                    freq[leftCharWindow]--;
                }
            }
        }

        return maxLength;
    }
}