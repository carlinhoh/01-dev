/*
https://leetcode.com/problems/evaluate-boolean-binary-tree/submissions/1260053859/

Time: O(n)
Space: O(n)
*/
public class Solution {
   public bool EvaluateTree(TreeNode root) {
        if (root.left == null && root.right == null)
        {
            return root.val == 1;
            }
        if (root.val == 2) {
            return EvaluateTree(root.right) || EvaluateTree(root.left);
        }
        return EvaluateTree(root.right) && EvaluateTree(root.left);
    }
}