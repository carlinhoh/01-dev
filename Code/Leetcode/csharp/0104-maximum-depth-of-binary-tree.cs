/*
https://leetcode.com/problems/maximum-depth-of-binary-tree/submissions/1209511403/

Time:O(N)
Space: O(N), if the tree is balanced O(logN)
 */
public class Solution {
    public int MaxDepth(TreeNode root) {
         if(root==null){
            return 0;
        }
        int left = MaxDepth(root.left);
        int right = MaxDepth(root.right);
        return Math.Max(right,left) + 1;
    }
}