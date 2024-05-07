/*
https://leetcode.com/problems/group-shifted-strings/submissions/1251956402/

Time: O(n * m), where m is the length of the largest string in strings
Space: O(n*m)
*/
public class Solution {
    public IList<IList<string>> GroupStrings(string[] strings) {
       Dictionary<string, List<string>> patterns = new();
        List<IList<string>> result = new List<IList<string>>();

        foreach (var s in strings) {
            string key = GetKey(s);
            if (!patterns.ContainsKey(key)) {
                patterns[key] = new List<string>();
            }
            patterns[key].Add(s);
        }
        
        foreach (var group in patterns.Values) {
            result.Add(group);
        }

        return result;
    }

    private string GetKey(string s) {
        if (s.Length == 1) return "1";

        StringBuilder keyBuilder = new StringBuilder();
        for (int i = 1; i < s.Length; i++) {
            int shift = (s[i] - s[i - 1] + 26) % 26;
            keyBuilder.Append(shift + ",");
        }

        return keyBuilder.ToString();
    }
}