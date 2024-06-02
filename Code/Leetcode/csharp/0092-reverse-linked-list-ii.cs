/*
https://leetcode.com/problems/reverse-linked-list-ii/submissions/1275609613/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        ListNode dummy = new ListNode(0, head);

        ListNode leftPrevious = dummy;
        ListNode current = head;
        for(int i=0;i<left-1;i++){
            leftPrevious = current;
            current = current.next;
        }

        ListNode previous = null;
        
        for(int i=0;i<(right - left + 1);i++){
            ListNode temp = current.next;
            current.next = previous;
            
            previous = current;
            current = temp;
        }

        leftPrevious.next.next = current;//current is node after right
        leftPrevious.next = previous;// prev is the the node in the right pos

        return dummy.next;
    }
}