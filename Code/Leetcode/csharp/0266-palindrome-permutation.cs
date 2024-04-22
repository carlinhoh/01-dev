/*
https://leetcode.com/problems/palindrome-permutation/submissions/1239303013/

Time: O(n)
Space: O(1), as 's' consists of only lowercase English letters.
*/
public class Solution {
    public bool CanPermutePalindrome(string s) {
        HashSet<char> wordsSet = new();

        foreach(var word in s){
            if(!wordsSet.Add(word)){
                wordsSet.Remove(word);
            }
        }

        return wordsSet.Count <= 1;
    }
}