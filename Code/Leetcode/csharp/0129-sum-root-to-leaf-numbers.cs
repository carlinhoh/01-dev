/*
https://leetcode.com/problems/sum-root-to-leaf-numbers/submissions/1250187603/

Time: O(n)
Space: O(h), where h is a tree height.
*/
public class Solution {
    int totalSum = 0;
    public int SumNumbers(TreeNode root) {
        InOrderDfs(root, 0);
        return totalSum;
    }

    public void InOrderDfs(TreeNode root, int sum){
        if(root == null){
            return;
        }

        sum = sum + root.val;

        InOrderDfs(root.left, sum*10);
        InOrderDfs(root.right, sum*10);

        if(root.left == null && root.right == null) totalSum += sum;
    }
}