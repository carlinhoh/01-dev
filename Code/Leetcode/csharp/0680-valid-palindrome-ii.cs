/*
https://leetcode.com/problems/valid-palindrome-ii/submissions/1243864579/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public bool ValidPalindrome(string s) {
        int left = 0;
        int right = s.Length-1;
        
        while(left<right){
            if(s[left] !=  s[right]){
                return CheckPalindrome(s, left+1, right) || CheckPalindrome(s, left, right-1);  
            }
            left++;
            right--;
        }
        
        return true;
    }
    
    public bool CheckPalindrome(string s, int left, int right){
        while(left<right){
            if(s[left]!=s[right]){
            return false;
            }
            left++;
            right--;
        }
        return true;
    }
}