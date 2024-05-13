/*
https://leetcode.com/problems/insert-into-a-sorted-circular-linked-list/submissions/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public Node Insert(Node head, int insertVal) {
        if(head == null){
            Node res = new Node(insertVal);
            res.next = res;
            return res;
        }
        Node node = head;

        while(node.next != head){
            if(node.val <= node.next.val) {
                if(insertVal >= node.val && insertVal <= node.next.val) {
                    break;
                }
            } else {
                if(insertVal >= node.val || insertVal <= node.next.val) {
                    break;
                }
            }
            node = node.next;
        }

        Node next = node.next;
        node.next = new Node(insertVal, next);
        
        return head;
    }
}