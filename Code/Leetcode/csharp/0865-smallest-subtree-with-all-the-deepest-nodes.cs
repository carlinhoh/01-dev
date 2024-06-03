/*
https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/submissions/1275841834/

Time: O(n)
Space: O(1)

https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/submissions/1275839835/

Time: O(n)
Space: O(1)
*/
public class Solution {
    int deepest = 0;
    TreeNode deep;
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        Dfs(root, 0);
        return deep;
    }
    private int Dfs(TreeNode root, int depth) {
        if (root == null) {
            return depth;
        }

        int left = Dfs(root.left, depth + 1);
        int right = Dfs(root.right, depth + 1);

        int currentDepth = Math.Max(left, right);

        if (left == right && currentDepth >= deepest) {
            deep = root;
            deepest = currentDepth;
        }

        return currentDepth;
    }
}
public class Solution {
    int deepest = 0;
    TreeNode deep;
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        Dfs(root, 0);
        return deep;
    }
    private int Dfs(TreeNode root, int depth){
        deepest = Math.Max(deepest, depth);
        if(root == null){
            return depth;
        }
        int left = Dfs(root.left, depth + 1);
        int right = Dfs(root.right, depth + 1);
        
        if(left == deepest && right == deepest){
            deep = root;
        }
        return Math.Max(left, right);
    }
}