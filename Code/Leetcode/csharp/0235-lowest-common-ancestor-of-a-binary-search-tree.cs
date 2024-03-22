/*
https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/submissions/1211162832/

Time: O(N)
Space: O(1)
*/

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        
        TreeNode candidate = root;

        while(candidate!=null){

            if(p.val > candidate.val && q.val > candidate.val){
                candidate = candidate.right;
            }
            else if(p.val < candidate.val && q.val < candidate.val){
                candidate = candidate.left;
            }
            else{
                return candidate;
            }
        }
        
        return default;
    }
}