/*
https://leetcode.com/problems/custom-sort-string/submissions/1250298046/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public string CustomSortString(string order, string s) {
        Dictionary<char, int> countChars = new();

        foreach(var letter in s){
            countChars[letter] = countChars.GetValueOrDefault(letter) + 1;
        }

        StringBuilder sb = new();
    
        for(int i=0;i<order.Length;i++){
            if(countChars.ContainsKey(order[i])){
                sb.Append(order[i], countChars[order[i]]);
                countChars.Remove(order[i]);
            }
        }

        foreach(var count in countChars){
            sb.Append(count.Key, count.Value);
        }

        return sb.ToString();
    }
}