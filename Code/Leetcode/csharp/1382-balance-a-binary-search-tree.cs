/*
https://leetcode.com/problems/balance-a-binary-search-tree/submissions/1301347527

Time: O(n)
Space: O(n)
*/
public class Solution {
    List<int> orderedTree = new List<int>();
    public TreeNode BalanceBST(TreeNode root) {
            Traversal(root);
            return CreateBalancedBST(orderedTree, 0, orderedTree.Count-1);
    }
    
    public void Traversal(TreeNode root){
        if(root==null){
            return;
        }
        Traversal(root.left);
        orderedTree.Add(root.val);
        Traversal(root.right);
    }
    
      public TreeNode CreateBalancedBST(List<int> list, int low, int high){
        if(low>high){
            return null;
        }
          int middle = (low + high)/2;
        
        TreeNode curr = new TreeNode(list[middle]);
        
        curr.left = CreateBalancedBST(list, low, middle-1);
        curr.right = CreateBalancedBST(list, middle+1, high);
        
        return curr;
        
    }
    
  
}