/*
https://leetcode.com/problems/diameter-of-binary-tree/submissions/1267483570/

Time: O(N)
Space: O(N)
*/
public class Solution {
    int total = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        Dfs(root);
        return total;
    }

    public int Dfs(TreeNode root){
        if(root == null){
            return 0;
        }

        int sizeLeft = Dfs(root.left);
        int sizeRight = Dfs(root.right);

        total = Math.Max(total, sizeLeft + sizeRight);

        return Math.Max(sizeLeft, sizeRight) + 1;
        
    }
}