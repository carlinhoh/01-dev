/*
https://leetcode.com/problems/decode-string/submissions/1271970274/

Time: O(maxKn)
Space: O(n)

*/
public class Solution {
    int index = 0;
    public string DecodeString(string s) {
        StringBuilder result = new();
        while(index < s.Length && s[index] != ']'){
            if (!char.IsDigit(s[index])){
                result.Append(s[index++]);
            }
            else{
                int k = 0;

                while (index < s.Length && char.IsDigit(s[index]))
                {
                    k = k * 10 + s[index++] - '0';
                }

                index++;//avoid [

                string decodedString = DecodeString(s);
                
                index++;// avoid ]

                while (k-- > 0)
                {
                    result.Append(decodedString);
                }
            }
        }

        return result.ToString();
    }
}