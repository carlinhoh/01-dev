/*
https://leetcode.com/problems/greatest-common-divisor-of-strings/submissions/1216587179/

Time: O(n+m)
Space: O(n+m)
*/

public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        if (!(str1 + str2).Equals(str2 + str1)) {
            return string.Empty;
        }

        if (str1.Length < str2.Length) {
            (str1, str2) = (str2, str1); 
        }
        
        return GetGcdOfStings(str1, str2);
    }

    public string GetGcdOfStings(string str1, string str2) {
        if (str1.Equals(str2)) {
            return str2;
        }
        
        string remainder = str1.Substring(str2.Length); 

        return GcdOfStrings(str2, remainder);
    }
}