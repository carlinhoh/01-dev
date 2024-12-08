/*
https://leetcode.com/problems/find-leaves-of-binary-tree/submissions/1473808834/

Time: O(n)
Space: O(n)
*/
public class Solution {
    List<IList<int>> leafs = new List<IList<int>>();
    public IList<IList<int>> FindLeaves(TreeNode root) {
        GetHeights(root);
        return leafs;
    }

    public int GetHeights(TreeNode root){
        if(root == null)
            return -1;
        int height = 1 + Math.Max(GetHeights(root.left), GetHeights(root.right));
        if (leafs.Count == height) 
            leafs.Add(new List<int>());
        leafs[height].Add(root.val);
        return height;
    }
}