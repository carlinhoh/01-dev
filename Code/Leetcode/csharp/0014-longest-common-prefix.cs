//https://leetcode.com/problems/longest-common-prefix/submissions/1148196075/
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        if(strs.Length == 0 || strs == null){
            return string.Empty;
        }
        if(strs.Length == 1 || strs.Length == 0){
            return strs[0];
        }

        for(int i=0;i<strs[0].Length;i++){
           for(int j=0;j<strs.Length;j++){
               if(i==strs[j].Length || strs[j][i]!= strs[0][i]){
                   return strs[0].Substring(0,i);
               }
           }
        }
       return strs[0]; 
    }
}