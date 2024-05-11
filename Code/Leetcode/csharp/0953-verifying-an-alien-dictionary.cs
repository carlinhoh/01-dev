/*
https://leetcode.com/problems/verifying-an-alien-dictionary/submissions/1212975309/

Time: O(K), where K is the number of characters in words
Space: O(1)
*/
public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        if(words.Length == 1){
            return true;
        }
        Dictionary<char, int> orderHash = new();

        for(int i=0;i<order.Length;i++){
            orderHash.Add(order[i], i);
        }

        for(int i=0;i<words.Length-1;i++){
            var firstWord = words[i];
            var secondWord = words[i+1];
            for(int j=0;j<firstWord.Length;j++){ 
                if(j>= secondWord.Length){
                    return false;
                }               
                var indexFirstWord = orderHash[firstWord[j]];
                var indexSecondWord= orderHash[secondWord[j]];
                if(indexFirstWord!=indexSecondWord){
                    if(indexFirstWord > indexSecondWord){
                        return false;
                    }
                    break;
                }
                
            }
        }
        return true;
    }
}