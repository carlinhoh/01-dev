/*
https://leetcode.com/problems/reorganize-string/submissions/1290582093/

Time: O(n)
Space: O(1)
*/
public class Solution{
    public string ReorganizeString(string s){
        int[] alphabet = new int[26];
        int max = 0;
        char letter = 'a';

        for (int i = 0; i < s.Length; i++)
        {
            alphabet[s[i] - 'a']++;
            if (max < alphabet[s[i] - 'a'])
            {
                max = alphabet[s[i] - 'a'];
                letter = s[i];
            }
        }

        if (max > (s.Length + 1) / 2)
        {
            return string.Empty;
        }

        char[] result = new char[s.Length];
        int index = 0;

        while (alphabet[letter - 'a'] > 0)
        {
            result[index] = letter;
            index += 2;
            alphabet[letter - 'a']--;
        }

        for (int i = 0; i < alphabet.Length; i++)
        {
            while (alphabet[i] > 0)
            {
                if (index >= s.Length)
                {
                    index = 1; 
                }
                result[index] = (char)(i + 'a');
                index += 2;
                alphabet[i]--;
            }
        }
        return new string(result);
    }
}
