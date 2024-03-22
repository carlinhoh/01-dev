/*
https://leetcode.com/problems/kth-smallest-element-in-a-bst/submissions/1211248310/

Time:O(N)
Space: O(N)
*/
public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        Stack<TreeNode> stack = new();
       
        while(true){
            while(root!=null){
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            if(--k==0){
                return root.val;
            }
            root = root.right;
        }
    }
}