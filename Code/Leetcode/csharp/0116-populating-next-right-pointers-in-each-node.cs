/*
https://leetcode.com/problems/populating-next-right-pointers-in-each-node/submissions/1272368741/

Time: O(n)
Space: O(n)

Recursive https://leetcode.com/problems/populating-next-right-pointers-in-each-node/submissions/1272754946/

Time: O(n)
Space: O(n)

BFS https://leetcode.com/problems/populating-next-right-pointers-in-each-node/submissions/1272364222/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public Node Connect(Node root) {
        if(root == null){
            return root;
        }

        Node leftmost = root;
        while(leftmost.left != null){
            Node head = leftmost;

            while(head != null){
                head.left.next = head.right;
                if(head.next != null){
                    head.right.next = head.next.left;
                }
                head = head.next;
            }
            leftmost = leftmost.left;
        }
        return root;
    }
}

public class Solution {
    public Node Connect(Node root) {
        if (root == null || root.left == null) {
            return root;
        }

        root.left.next = root.right;
        if (root.next != null) {
            root.right.next = root.next.left;
        }

        Connect(root.left);
        Connect(root.right);

        return root;
    }
}

public class Solution {
    public Node Connect(Node root) {
        if(root == null){
            return root;
        }
        Queue<Node> q = new();
        q.Enqueue(root);

        while(q.Any()){
            int level = q.Count;
            
            for(int i=0;i<level;i++){
                Node current = q.Dequeue();
                if(i < level - 1){
                    current.next = q.Peek();
                }

                if(current.left != null){
                    q.Enqueue(current.left);
                }
                if(current.right != null){
                    q.Enqueue(current.right);
                }
                current = current.next;
            }
        }

        return root;
    }
}