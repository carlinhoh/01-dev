/*
https://leetcode.com/problems/invert-binary-tree/submissions/1209505825/

Time:O(N)
Space:O(H), Where H is the height of the tree   
*/
public class Solution {
    public TreeNode InvertTree(TreeNode root) {
       Invert(root);
       return root;
    }

    private void Invert(TreeNode root){
         if(root==null){
            return;
        }
        var aux = root.left;
        root.left = root.right;
        root.right = aux;
        Invert(root.left);
        Invert(root.right);
    }
}