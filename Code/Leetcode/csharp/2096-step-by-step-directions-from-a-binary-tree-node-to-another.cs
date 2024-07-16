/*
https://leetcode.com/problems/step-by-step-directions-from-a-binary-tree-node-to-another/submissions/1323460602/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        StringBuilder startPath = new StringBuilder();
        StringBuilder destPath = new StringBuilder();

        FindPath(root, startValue, startPath);
        FindPath(root, destValue, destPath);

        StringBuilder directions = new StringBuilder();
        int commonPathLength = 0;

        while (commonPathLength < startPath.Length &&
               commonPathLength < destPath.Length &&
               startPath[commonPathLength] == destPath[commonPathLength]) {
            commonPathLength++;
        }

        for (int i = 0; i < startPath.Length - commonPathLength; i++) {
            directions.Append("U");
        }

        for (int i = commonPathLength; i < destPath.Length; i++) {
            directions.Append(destPath[i]);
        }

        return directions.ToString();
    }

    private bool FindPath(TreeNode node, int target, StringBuilder path) {
        if (node == null) return false;

        if (node.val == target) return true;

        path.Append("L");
        if (FindPath(node.left, target, path)) return true;
        path.Remove(path.Length - 1, 1);

        path.Append("R");
        if (FindPath(node.right, target, path)) return true;
        path.Remove(path.Length - 1, 1);

        return false;
    }
}
