/*
https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-ii/submissions/1270733823/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var result = FindLCA(root, p, q);

        if(result == p){
            if(FindNode(p, q)) return p;
            return null;
        } 
        else if(result == q){
            if(FindNode(q, p)) return q;
            return null;
        } 

        return result;
    }

    public TreeNode FindLCA(TreeNode root, TreeNode p, TreeNode q){
        if(root == null|| root == p || root == q) return root;
        TreeNode left = FindLCA(root.left, p, q);
        TreeNode right = FindLCA(root.right, p, q);
        return left != null && right != null ? root : left == null ? right : left; 
    }

    public bool FindNode(TreeNode root, TreeNode target){
        if(root == target){
            return true;
        }
        if(root == null){
            return false;
        }
        
        return FindNode(root.left, target) || FindNode(root.right, target);
    }
}