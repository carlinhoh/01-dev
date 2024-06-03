/*
https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/submissions/1276802271/

Time: O(n)
Space: O(n)

https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/submissions/1276795705/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        return LcaDeepestLeavesAndDepth(root).Node;
    }

    public (TreeNode Node, int Depth) LcaDeepestLeavesAndDepth(TreeNode root) {
        if(root == null) return (null, 0);

        var leftResult = LcaDeepestLeavesAndDepth(root.left);
        var rightResult = LcaDeepestLeavesAndDepth(root.right);

        if(leftResult.Depth == rightResult.Depth) return (root, leftResult.Depth + 1);
        if(leftResult.Depth > rightResult.Depth) return (leftResult.Node, leftResult.Depth + 1);
        return (rightResult.Node, rightResult.Depth + 1);
    }
}

public class Solution {
    int deepest = 0;
    TreeNode lca;
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        Dfs(root, 0);
        return lca;
    }

    private int Dfs(TreeNode root, int depth){
        deepest = Math.Max(deepest, depth);
        if(root == null){
            return depth;
        }
        int left = Dfs(root.left, depth + 1);
        int right = Dfs(root.right, depth + 1);

        if(left == deepest && right == deepest){
            lca = root;
        }
        return Math.Max(left, right);
    }
}