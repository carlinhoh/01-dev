/*

Dfs https://leetcode.com/problems/range-sum-of-bst/submissions/1266682326/

Time: O(N)
Space: O(N)

Morris https://leetcode.com/problems/range-sum-of-bst/submissions/1266687063/

Time: O(N)
Space: O(1)

*/
public class Solution {
    public int RangeSumBST(TreeNode root, int low, int high) {
        if(root == null){
            return 0;
        }    
        if(root.val < low){
            return RangeSumBST(root.right, low, high);
        }
        if(root.val > high){
            return RangeSumBST(root.left, low, high);
        }
        return root.val + RangeSumBST(root.right, low, high) +  RangeSumBST(root.left, low, high);
    }
}

public class Solution {
    public int RangeSumBST(TreeNode root, int low, int high) {
               int sum = 0;
        TreeNode current = root;

        while (current != null) {
            if (current.left == null) {
                // Process current node if it's within the range
                if (current.val >= low && current.val <= high) {
                    sum += current.val;
                }
                current = current.right;
            } else {
                // Find the inorder predecessor of current
                TreeNode predecessor = current.left;
                while (predecessor.right != null && predecessor.right != current) {
                    predecessor = predecessor.right;
                }

                if (predecessor.right == null) {
                    // Establish thread
                    predecessor.right = current;
                    current = current.left;
                } else {
                    // Remove thread
                    predecessor.right = null;
                    // Process current node if it's within the range
                    if (current.val >= low && current.val <= high) {
                        sum += current.val;
                    }
                    current = current.right;
                }
            }
        }
        return sum;
    }
}