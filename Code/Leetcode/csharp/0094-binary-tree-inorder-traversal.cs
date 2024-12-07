/*
https://leetcode.com/problems/binary-tree-inorder-traversal/submissions/1473021783/

Time: O(n)
Space: O(n)
*/

public class Solution {
    List<int> traversal = new();
    public IList<int> InorderTraversal(TreeNode root) {
        InOrderDfs(root);
        return traversal;
    }

    private void InOrderDfs(TreeNode root){
        if(root == null){
            return;
        }
        InOrderDfs(root.left);
        traversal.Add(root.val);
        InOrderDfs(root.right);
    }
}