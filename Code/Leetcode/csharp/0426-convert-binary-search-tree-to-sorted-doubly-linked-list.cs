/*
https://leetcode.com/problems/convert-binary-search-tree-to-sorted-doubly-linked-list/submissions/1244446365/

Time:O(n)
Space:O(n),  O(logn) for the best case of a completely balanced tree and O(n) for the worst case of a completely unbalanced tree.
*/

public class Solution {

    Node first;
    Node last;

    public Node TreeToDoublyList(Node root) {
        
        if(root == null){
            return null;
        }

        InOrderDfs(root);

        last.right = first;
        first.left = last;

        return first;
    }

    public void InOrderDfs(Node root){
        if(root == null){
            return;
        }

        InOrderDfs(root.left);
        
        if(last != null){
            last.right = root;
            root.left = last;
        }
        else{
            first = root;
        }
        last = root;
        
        InOrderDfs(root.right);
    }
}