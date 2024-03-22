/*
https://leetcode.com/problems/same-tree/submissions/1211039053/

Time: O(N)
Space: O(N)
*/
public class Solution {
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