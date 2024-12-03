/*
Recursive
https://leetcode.com/problems/delete-node-in-a-bst/submissions/1468754417/

Time: O(h)
Space: O(h)

Iterative
https://leetcode.com/problems/delete-node-in-a-bst/submissions/1468807447/

Time: O(h)
Space: O(1)
*/
public class Solution {
    public TreeNode DeleteNode(TreeNode root, int key) {
        if(root == null){
            return null;
        }

        if(root.val < key){
            root.right = DeleteNode(root.right, key);
        }
        else if(root.val > key){
            root.left = DeleteNode(root.left, key);
        }
        else{
            if(root.left == null || root.right == null){
                return root.left == null ? root.right : root.left;
            }
            else{
                var minNodeOnRight = FindMinNode(root.right);
                root.val = minNodeOnRight.val;
                root.right = DeleteNode(root.right, minNodeOnRight.val);
            }
        }
        return root;
    }

    public TreeNode FindMinNode(TreeNode root){
        var minLeaf = root;
        while(minLeaf != null && minLeaf.left != null){
            minLeaf = minLeaf.left;
        }
        return minLeaf;
    }
    
}