/*
Iterative Solution
https://leetcode.com/problems/search-in-a-binary-search-tree/submissions/1466146907/

Time: O(h)
Space: O(1)

Recursive Solution
https://leetcode.com/problems/search-in-a-binary-search-tree/submissions/1466145898/

Time: O(h)
Space: O(h)
    where h is a tree height
*/

public class Solution {
    public TreeNode SearchBST(TreeNode root, int val) {
        while(root!=null){
            if(root.val < val){
                root = root.right;
            }
            else if(root.val > val){
                root = root.left;
            }
            else return root;
        }
        return root;
    }
}
public class Solution {
    public TreeNode SearchBST(TreeNode root, int val) {
        if(root == null){
            return null;
        }

        if(root.val > val)
            return SearchBST(root.left, val);
        else if(root.val < val)
            return SearchBST(root.right, val);
        else 
            return root;
    }
}