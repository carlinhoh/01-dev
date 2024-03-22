/*
https://leetcode.com/problems/validate-binary-search-tree/submissions/1211190258/

Time:O(N)
Space:O(N)
*/

public class Solution {
    public bool IsValidBST(TreeNode root) {
       return IsValid(root, null, null);
    }

    private bool IsValid(TreeNode root, int? low, int? high){
         if(root == null){
            return true;
        }
        if((low != null && root.val <= low) || (high != null && root.val >= high)){
            return false;
        }

        return IsValid(root.left, low, root.val) && IsValid(root.right, root.val, high);
    }
}