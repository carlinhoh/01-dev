/**
#blind-75
#neetcode-150
https://leetcode.com/problems/valid-anagram/submissions/1151034459/
**/

public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length){
            return false;
        }

        int[] alpha = new int[26];

        for(int i=0;i<s.Length;i++){
            alpha[s[i]-'a']++;
            alpha[t[i]-'a']--;
        }

        for(int k=0;k<alpha.Length-1;k++){
            if(alpha[k]!=0){
                return false;
            }
        }
        return true;
    }
}



// public class Solution {
//     public bool IsAnagram(string s, string t) {
        
//         if(s.Length!=t.Length){
//             return false;
//         }
        
//         if(s==t){
//             return true;
//         }

//         int[] alpha = new int[26];
        
//         for(int i=0;i<s.Length;i++){
//             alpha[s[i] - (int)'a']++;
//         }

//         for(int i=0;i<t.Length;i++){
//             alpha[t[i] - (int)'a']--;
//             if(alpha[t[i] - (int)'a']<0){
//                 return false;
//             }
//         }
//         return true;
//     }
// }

