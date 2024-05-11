/*
https://leetcode.com/problems/binary-search-tree-iterator/submissions/1251139564/

Time: O(n)
Space; O(n)
*/
public class BSTIterator {
    Stack<TreeNode> stack;
    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        PushAllLeft(root);
    }
    
    public int Next() {
        TreeNode tmpNode = stack.Pop();
        if(tmpNode.right != null){
            PushAllLeft(tmpNode.right);
        }        
        return tmpNode.val;
    }
    
    public bool HasNext() {
        return stack.Count > 0;
    }

    private void PushAllLeft(TreeNode node){
        while(node != null){
            stack.Push(node);
            node = node.left;
        }
    }
}