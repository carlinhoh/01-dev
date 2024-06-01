/*
https://leetcode.com/problems/diameter-of-n-ary-tree/submissions/1274488759/

Time: O(n)
Space: O(n)
*/
public class Solution {
    int diameter = 0;
    public int Diameter(Node root) {
        MaxDepth(root, 0);
        return diameter;
    }
    private int MaxDepth(Node node, int currDepth)
    {
        if (node.children.Count == 0)
            return currDepth;

        int maxDepth1 = currDepth, maxDepth2 = 0;
        foreach (Node child in node.children)
        {
            int depth = MaxDepth(child, currDepth + 1);
            if (depth > maxDepth1)
            {
                maxDepth2 = maxDepth1;
                maxDepth1 = depth;
            }
            else if (depth > maxDepth2)
            {
                maxDepth2 = depth;
            }
            int distance = maxDepth1 + maxDepth2 - 2 * currDepth;
            this.diameter = Math.Max(this.diameter, distance);
        }

        return maxDepth1;
    }
}