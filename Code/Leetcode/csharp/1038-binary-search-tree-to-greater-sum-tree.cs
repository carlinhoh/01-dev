/*
https://leetcode.com/problems/binary-search-tree-to-greater-sum-tree/submissions/1299286604/

Time: O(n)
Space: O(n)
*/
public class Solution {
    int left = 0;
    public TreeNode BstToGst(TreeNode root) {
        UpdateValues(root);
        return root;
    }
    
    private void UpdateValues(TreeNode root){
        if(root==null){
            return;
        }
        UpdateValues(root.right);
        left+=root.val;
        root.val = left;
        UpdateValues(root.left);
    }
}