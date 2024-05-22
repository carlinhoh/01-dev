/*
https://leetcode.com/problems/merge-two-binary-trees/submissions/1264480798/

Time: O(n)
Space: O(n)


https://leetcode.com/problems/merge-two-binary-trees/submissions/1264485021/

Time: O(m) where m represents the minimum number of nodes
Space: O(m)

*/
public class Solution {
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        return SumTrees(root1, root2);
    }

    public TreeNode SumTrees(TreeNode root1, TreeNode root2){
        if(root1 == null && root2 == null){
            return null;
        }
        root1 = root1 == null ? new TreeNode(0) : root1;
        root2 = root2 == null ? new TreeNode(0) : root2;

        root1.val += root2.val;

        root1.left = SumTrees(root1.left, root2.left);
        root1.right = SumTrees(root1.right, root2.right);
        
        return root1;
    }
}

public class Solution {
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        return SumTrees(root1, root2);
    }

    public TreeNode SumTrees(TreeNode root1, TreeNode root2){
        if(root1 == null){
            return root2;
        }
        if(root2 == null){
            return root1;
        }

        root1.val += root2.val;

        root1.left = SumTrees(root1.left, root2.left);
        root1.right = SumTrees(root1.right, root2.right);
        
        return root1;
    }
}