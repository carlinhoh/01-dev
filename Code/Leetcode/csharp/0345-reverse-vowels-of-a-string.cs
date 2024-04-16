/*
https://leetcode.com/problems/reverse-vowels-of-a-string/submissions/1233422904/

Time: O(N)
Space: O(1)
*/


public class Solution {
    public string ReverseVowels(string s) {
        HashSet<char> vowels = new(){'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        
        int left = 0;
        int right = s.Length-1;

        StringBuilder sb = new(s);

        while(left<right){
            if(vowels.Contains(s[left])){
                if(vowels.Contains(s[right])){
                    var c = s[left];
                    sb[left] = s[right];
                    sb[right] = c;
                    left++;
                }
                right--;
            }
            else{
                left++;
            }
        }

        return sb.ToString();
    }
}