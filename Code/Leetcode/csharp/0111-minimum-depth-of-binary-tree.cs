/*
https://leetcode.com/problems/minimum-depth-of-binary-tree/submissions/1259025441/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public int MinDepth(TreeNode root) {
        if(root == null){
            return 0;
        }
        if(root.left == null){
            return MinDepth(root.right) + 1;
        }
        if(root.right == null){
             return MinDepth(root.left) + 1;
        }

        return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
    }
}