/*
https://leetcode.com/problems/balanced-binary-tree/submissions/1274598151/

Time: O(n)
Space: O(n)

https://leetcode.com/problems/balanced-binary-tree/submissions/1274599287/

Time: O(n)
Space: O(n)

*/
public class Solution{
    public bool IsBalanced(TreeNode root){
        return CheckHeight(root) != -1;
    }

    private int CheckHeight(TreeNode node){
        if (node == null) return 0;
        
        int leftHeight = CheckHeight(node.left);
        if (leftHeight == -1){
            return -1;
        }

        int rightHeight = CheckHeight(node.right);
        if (rightHeight == -1){
            return -1;
        }

        if (Math.Abs(leftHeight - rightHeight) > 1){
            return -1;
        }

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}

public class Solution {
    public bool IsBalanced(TreeNode root) {
        return GetHeight(root) != -1;
    }

    private int GetHeight(TreeNode node) {
        if (node == null) return 0;

        int left = GetHeight(node.left);
        int right = GetHeight(node.right);

        // If the left or right subtree is unbalanced, or the current node is unbalanced
        if (left == -1 || right == -1 || Math.Abs(left - right) > 1) return -1;

        return Math.Max(left, right) + 1;
    }
}