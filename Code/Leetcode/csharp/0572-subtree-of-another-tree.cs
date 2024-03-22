/*
https://leetcode.com/problems/subtree-of-another-tree/submissions/1211131140/

Time: O(MN)
Space: O(M + N)
*/
public class Solution {
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if(root == null){
            return false;
        }
        if(root.val == subRoot.val && IsSameTree(root, subRoot)){
           return true;
        }
       
       return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

      public bool IsSameTree(TreeNode p, TreeNode q) {
        if(p==null && q==null){
            return true;
        }
        else if(p==null || q==null){
            return false;
        }
        if(p.val != q.val){
            return false;
        }
        return IsSameTree(p.left, q.left) && IsSameTree(q.right, p.right);
    }
}