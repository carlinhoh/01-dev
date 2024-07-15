/*
https://leetcode.com/problems/create-binary-tree-from-descriptions/submissions/1322299531/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        var nodeMap = new Dictionary<int, TreeNode>();
        var children = new HashSet<int>();

        foreach (var description in descriptions) {
            int parentValue = description[0];
            int childValue = description[1];
            bool isLeft = description[2] == 1;

            if (!nodeMap.ContainsKey(parentValue)) {
                nodeMap[parentValue] = new TreeNode(parentValue);
            }
            if (!nodeMap.ContainsKey(childValue)) {
                nodeMap[childValue] = new TreeNode(childValue);
            }

            if (isLeft) {
                nodeMap[parentValue].left = nodeMap[childValue];
            } else {
                nodeMap[parentValue].right = nodeMap[childValue];
            }

            children.Add(childValue);
        }

        foreach (var node in nodeMap.Values) {
            if (!children.Contains(node.val)) {
                return node;
            }
        }

        return null;
    }
}
