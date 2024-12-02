/*
Recursive
https://leetcode.com/problems/insert-into-a-binary-search-tree/submissions/1468742836/

Time: O(n), can be O(h) ~ O(log(n)) if the tree is balanced
Space: O(n), can be O(h) ~ O(log(n)) if the tree is balanced

Iterative
https://leetcode.com/problems/insert-into-a-binary-search-tree/submissions/1468745778/

Time: O(n), can be O(h) ~ O(log(n)) if the tree is balanced
Space: O(1)

*/
public class Solution {
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if(root == null){
            return new TreeNode(val);
        }

        if(root.val < val){
            root.right = InsertIntoBST(root.right, val);
        }
        else{
            root.left = InsertIntoBST(root.left, val);
        }
        return root;
    }
}

public class Solution {
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        var dummy = root;
        while(root != null){
            if(val > root.val){
                if(root.right == null){
                    root.right = new TreeNode(val);
                    return dummy;
                }
                root = root.right;
            }
            else{
                if(root.left == null){
                    root.left = new TreeNode(val);
                    return dummy;
                }
                root = root.left;
            }
        }

        return new TreeNode(val);
    }
}