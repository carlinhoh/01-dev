/*
Sliding window https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/submissions/1257149132/

Time: O(n*m)
Space: O(1)

*/
public class Solution {
    public int StrStr(string haystack, string needle) {
        int m = needle.Length;
        int n = haystack.Length;

        if (n < m)
            return -1;
            
        int left = 0;
        int right = 0;

        while(right < haystack.Length){
            if(needle[left] ==  haystack[right]){
                left++;
                right++;
                if(left >= needle.Length){
                    return right - left;
                }
            }
            else{
                right++;
                if(left > 0){
                    right -= left;
                    left = 0;
                }
            }
        }
        return -1;
    }
}