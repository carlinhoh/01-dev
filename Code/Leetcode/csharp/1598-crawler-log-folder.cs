/*
https://leetcode.com/problems/crawler-log-folder/submissions/1317057369/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int MinOperations(string[] logs) {
        int folderDepth = 0;

        foreach (string currentOperation in logs) {
            if (currentOperation == "../") {
                folderDepth = Math.Max(0, folderDepth - 1);
            }
            else if (currentOperation != "./") {
                folderDepth++;
            }
        }

        return folderDepth;
    }
}
