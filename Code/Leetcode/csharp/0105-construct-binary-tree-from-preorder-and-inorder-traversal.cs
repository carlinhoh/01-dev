/*
https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/submissions/1211708862/

Time: O(N)
Space: O(N)
*/

public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        
        if(preorder.Length ==1 ){
            return new TreeNode(preorder[0]);
        }

        Dictionary<int, int> inorderIndexMap = new();
        for(int i=0;i<preorder.Length;i++){
            inorderIndexMap[inorder[i]] = i;
        }

        int[] preorderIndex = new int[1] {0};

        return ArrayToTree(preorder, inorderIndexMap, preorderIndex, 0, preorder.Length - 1);
    }

    private TreeNode ArrayToTree(int[] preorder, Dictionary<int, int> inorderIndexMap, int[] preorderIndex, int left, int right) {
        if (left > right) return null;

        int rootValue = preorder[preorderIndex[0]++];
        TreeNode root = new TreeNode(rootValue);
        
        root.left = ArrayToTree(preorder, inorderIndexMap, preorderIndex, left, inorderIndexMap[rootValue] - 1);
        root.right = ArrayToTree(preorder, inorderIndexMap, preorderIndex, inorderIndexMap[rootValue] + 1, right);

        return root;
    }
}


public class Solution {
    private int preorderIndex;
    private Dictionary<int, int> inorderIndexMap;

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        preorderIndex = 0;
        inorderIndexMap = new Dictionary<int, int>();
        
        for(int i = 0; i < inorder.Length; i++){
            inorderIndexMap.Add(inorder[i], i);
        }

        return BuildTreeHelper(preorder, preorderIndex, preorder.Length - 1);
    }

    private TreeNode BuildTreeHelper(int[] preorder, int left, int right) {
        if(left > right){
            return null;
        }

        int rootValue = preorder[preorderIndex++];
        TreeNode root = new TreeNode(rootValue);

        root.left = BuildTreeHelper(preorder, left, inorderIndexMap[rootValue] - 1);
        root.right = BuildTreeHelper(preorder, inorderIndexMap[rootValue] + 1, right);
        
        return root;
    }
}
