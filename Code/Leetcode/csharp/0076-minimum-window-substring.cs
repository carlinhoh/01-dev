/*
#blind-75
#neetcode-150
https://leetcode.com/problems/minimum-window-substring/submissions/1157817219/

Time:O(N)
Space:O(1) 
*/

public class Solution {
    public string MinWindow(string s, string t) {
        int[] charMap = new int[128];

        foreach (char c in t)
        {
            charMap[c]++;
        }
        
        int start = 0;
        int end = 0;
        int minLength = int.MaxValue;
        int minStart = 0;
        int counter = t.Length;

        while (end < s.Length)
        {
            if (charMap[s[end]] > 0)
            {
                counter--;
            }
            charMap[s[end]]--;
            end++;
            while (counter == 0)
            {
                if (minLength > end - start)
                {
                    minLength = end - start;
                    minStart = start;
                }
                charMap[s[start]]++;
                if (charMap[s[start]] > 0)
                {
                    counter++;
                }

                start++;
            }
        }
        
        return minLength == int.MaxValue ? "" : s.Substring(minStart, minLength);
    }
}