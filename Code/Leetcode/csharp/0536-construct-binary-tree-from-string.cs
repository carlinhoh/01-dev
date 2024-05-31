/*
https://leetcode.com/problems/construct-binary-tree-from-string/submissions/1273662300/

Time: O(n)
Space: O(h), where h is the height of the tree
*/
public class Solution {
    int index = 0;
    public TreeNode Str2tree(string s) {
        if (index >= s.Length || s[index] == ')') {
            return null;
        }
        
        // Parse the number
        int val = 0;
        bool negative = false;
        if (s[index] == '-') {
            negative = true;
            index++;
        }
        
        while (index < s.Length && char.IsDigit(s[index])) {
            val = val * 10 + (s[index] - '0');
            index++;
        }
        
        if (negative) {
            val = -val;
        }

        TreeNode root = new TreeNode(val);

         if (index < s.Length && s[index] == '(') {
            index++; // Move past '('
            root.left = Str2tree(s);
            index++; // Move past ')'
        }

        if (index < s.Length && s[index] == '(') {
            index++; // Move past '('
            root.right = Str2tree(s);
            index++; // Move past ')'
        }

        return root;
    }
}