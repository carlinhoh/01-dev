/*
https://leetcode.com/problems/closest-binary-search-tree-value/submissions/1238602684/

Time: O(H), Where H is the tree height
Space: O(1)
*/
public class Solution {
    public int ClosestValue(TreeNode root, double target) {

        int closest = root.val;

        while(root != null){
            closest = (Math.Abs(closest - target) <  Math.Abs(root.val - target))
                ||    (Math.Abs(closest - target) ==  Math.Abs(root.val - target) && closest < root.val) ? closest :  root.val;

            root = target < root.val ? root.left : root.right;
        }

        return closest;
    }
}