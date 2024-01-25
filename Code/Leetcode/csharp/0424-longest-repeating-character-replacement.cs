/*
#neetcode-150
https://leetcode.com/problems/longest-repeating-character-replacement/submissions/1156868127/

Time: O(N)
Space: O(K) where K, in this case 26, so O(1) 
*/
public class Solution {
    public int CharacterReplacement(string s, int k) {
       int windowStart = 0;
       int maxLength = 0;
       int repeatCount = 0;
       Dictionary<char, int> freq = new();

       for(int windowEnd=0;windowEnd<s.Length;windowEnd++){
           char rightChar = s[windowEnd];
           freq.TryAdd(rightChar, 0);
           freq[rightChar]++;
           repeatCount = Math.Max(repeatCount, freq[rightChar]);
           if(windowEnd - windowStart + 1 - repeatCount > k){
               char leftChar = s[windowStart];
               freq[leftChar]--;
               windowStart++;
           }
           maxLength = Math.Max(maxLength, windowEnd-windowStart+1);
       }
       
       return maxLength;
    }
}