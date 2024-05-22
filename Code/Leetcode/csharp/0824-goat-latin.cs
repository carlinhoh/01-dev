/*
https://leetcode.com/problems/goat-latin/submissions/1265097693/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public string ToGoatLatin(string sentence) {
        HashSet<char> vowels = new() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        StringBuilder result = new();
        int aCount = 1;
        
        foreach (var word in sentence.Split(" "))
        {
            if (vowels.Contains(word[0]))
            {
                result.Append(word);
            }
            else
            {
                result.Append(word.Substring(1)).Append(word[0]);
            }
            
            result.Append("ma");
            result.Append('a', aCount);
            result.Append(' ');
            aCount++;
        }

        // Remove the last space
        result.Remove(result.Length - 1, 1);

        return result.ToString();
    }
}
public class Solution {
    public string ToGoatLatin(string sentence) {
        HashSet<char> vowels = new(){ 'a', 'e', 'i', 'o', 'u'};
        var sentences = sentence.Split(" ");
        StringBuilder sb = new();
        int aCount = 1;
        foreach(var word in sentences){
            char firstChar = char.ToLower(word[0]);
            if(vowels.Contains(firstChar)){
                sb.Append(ConvertSentence(word, aCount));
            }
            else{
                sb.Append(ConvertSentence(word.Substring(1) + word[0], aCount));
            }
            aCount++;
        }
        sb.Remove(sb.Length - 1, 1); // Remove the last space
        return sb.ToString();
    }
    public string ConvertSentence(string sentence, int aCount){
        StringBuilder sb = new(sentence);
        sb.Append("ma");
        sb.Append('a', aCount);
        sb.Append(" ");
        return sb.ToString();
    }
}