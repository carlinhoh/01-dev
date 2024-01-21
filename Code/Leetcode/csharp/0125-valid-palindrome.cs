/*
#blind-75
#neetcode-150
https://leetcode.com/problems/valid-palindrome/submissions/1153031329/

Time: O(N)
Space: O(1)
*/

public class Solution {
    public bool IsPalindrome(string s) {
        s = s.ToLower();
        int left = 0;    
        int right = s.Length-1;
        
        while(left<right){
           if(!char.IsLetterOrDigit(s[left])){                
                left++;
           }
           else if(!char.IsLetterOrDigit(s[right])){                
                right--;
           }
           else if(s[left++]!=s[right--]){
               return false;
           }
        }
        return true;
    }
}