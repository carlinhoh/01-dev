/*

https://leetcode.com/problems/number-of-good-leaf-nodes-pairs/submissions/1325682358/
Time: O(n * d²), dis the max distance 
Space: O(H), height of binary tree
*/
public class Solution {
    public int CountPairs(TreeNode root, int distance) {
        return PostOrder(root, distance)[distance + 1];
    }

    private int[] PostOrder(TreeNode node, int distance) {
        if (node == null) return new int[distance + 2];
        if (node.left == null && node.right == null) {
            int[] leaf = new int[distance + 2];
            leaf[0] = 1;
            return leaf;
        }

        int[] left = PostOrder(node.left, distance);
        int[] right = PostOrder(node.right, distance);

        int[] count = new int[distance + 2];

        for (int i = 0; i < distance; i++) {
            count[i + 1] += left[i] + right[i];
        }

        count[distance + 1] += left[distance + 1] + right[distance + 1];

        for (int d1 = 0; d1 <= distance; d1++) {
            for (int d2 = 0; d2 <= distance; d2++) {
                if (d1 + d2 + 2 <= distance) {
                    count[distance + 1] += left[d1] * right[d2];
                }
            }
        }

        return count;
    }
}
