/*
https://leetcode.com/problems/binary-tree-maximum-path-sum/submissions/1248345696/

Time: O(n)
Space: O(n)
*/

public class Solution {

    int totalSum = 0;

    public int MaxPathSum(TreeNode root) {
        if(root.left == null && root.right == null && root != null){
            return root.val;
        }
        totalSum = root.val;    

        MaxGain(root);

        return totalSum;
    }

    private int MaxGain(TreeNode node)
    {
        if (node == null) return 0;

        int leftGain = Math.Max(MaxGain(node.left), 0);
        int rightGain = Math.Max(MaxGain(node.right), 0);

        int currentPathSum = node.val + leftGain + rightGain;

        totalSum = Math.Max(totalSum, currentPathSum);

        return node.val + Math.Max(leftGain, rightGain);
    }
}