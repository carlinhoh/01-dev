public class Solution {
    public string LongestPalindrome(string s) {

        string res = "";
        int resLen = 0;

        for(int i=0;i<s.Length;i++){
            int left = i;
            int right = i;

            while(left >=0 && right<s.Length && s[left] == s[right]){
                if(right-left+1>resLen){
                    res = s.Substring(left, right-left+1);
                    resLen = right-left+1;
                }
                left--;
                right++;
            }

            left = i;
            right = i+1;
            while(left >=0 && right<s.Length && s[left] == s[right]){
                if(right-left+1>resLen){
                    res = s.Substring(left, right-left+1);
                    resLen = right-left+1;
                }
                left--;
                right++;
            }
        }
        return res;
    }
}