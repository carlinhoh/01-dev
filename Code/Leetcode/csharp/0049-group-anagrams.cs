/**
#blind-75
#neetcode-150
https://leetcode.com/problems/group-anagrams/submissions/1151061206/
**/

public class Solution {
   public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dic = new();

            foreach(var str in strs){
                char[] alpha = new char[26];

                for(int i=0;i<str.Length;i++){
                    alpha[str[i] - 'a']++;
                }
                string key = new string(alpha);
                Console.WriteLine(key);
                if(dic.ContainsKey(key)){
                    dic[key].Add(str);
                }
                else{
                    dic[key] = new List<string>(){str};
                }
            }
            return new List<IList<string>>(dic.Values); 
        }
}

// public class Solution {
//     public IList<IList<string>> GroupAnagrams(string[] strs) {
//         Dictionary<string, List<string>> anagrams = new();

//         for(int i=0;i<strs.Length;i++){
//             int[] alpha = new int[26];
//             for(int j=0;j<strs[i].Length;j++){
//                 alpha[strs[i][j]-'a']++;
//             }
//             StringBuilder sb = new();
//             for(int j=0;j<alpha.Length;j++){
//                 sb.Append(alpha[j]);
//                 sb.Append("#");
//             }
//             if(anagrams.ContainsKey(sb.ToString())){
//                 anagrams[sb.ToString()].Add(strs[i]);
//             }
//             else anagrams.Add(sb.ToString(), new List<string>(){strs[i]});
//         }

//         List<IList<string>> groupedAnagrams = new();

//         foreach(var item in anagrams){
//             groupedAnagrams.Add(item.Value);
//         }

//         return groupedAnagrams;
//     }
// }
