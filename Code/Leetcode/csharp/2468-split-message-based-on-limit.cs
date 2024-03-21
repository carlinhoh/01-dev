/*
https://leetcode.com/problems/split-message-based-on-limit/submissions/1210183800/

Time: O(N)
Space: O(N)
*/

public class Solution {
    public string[] SplitMessage(string s, int limit) {
        int cur = 0, k = 0, i = 0; // Initialize variables
        // Loop to calculate the number of parts (k) based on the limit
        while (3 + k.ToString().Length * 2 < limit && cur + s.Length + (3 + k.ToString().Length) * k > limit * k) {
            k += 1; // Increment k
            cur += k.ToString().Length; // Update cur with the new total length of the digits of k
        }
        
        List<string> res = new List<string>(); // List to store the divided parts
        // If there is enough space for the suffix
        if (3 + k.ToString().Length * 2 < limit) {
            for (int j = 1; j <= k; j++) {
                // Calculate the available space for the text
                int l = limit - (j.ToString().Length + 3 + k.ToString().Length);
                // Ensure it does not go beyond the end of the string
                l = Math.Min(l, s.Length - i);
                // Add the current part to the list with the appropriate suffix
                res.Add(s.Substring(i, l) + $"<{j}/{k}>");
                i += l; // Update the index for the next part
            }
        }
        
        return res.ToArray(); // Convert the list to an array and return
    }
}
