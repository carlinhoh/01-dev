/*
https://leetcode.com/problems/reverse-linked-list/submissions/1455681081/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public ListNode ReverseList(ListNode head) {
        return Reverse(head);
        ListNode previous = null;
        ListNode curr = head;
        
        while(curr != null){
            var temp = curr.next;
            curr.next = previous;
            previous = curr;
            curr = temp;
        }

        return previous;
    }

    public ListNode Reverse(ListNode head, ListNode previous){
        if(head==null){
            return previous;
        }
        ListNode current = head;
        ListNode nextCurrent = current.next;
        current.next = previous;
        previous = current;
        return Reverse(nextCurrent,previous);
    }

    public ListNode Reverse(ListNode head){
        if(head == null || head.next == null){
            return head;
        }

        ListNode p = Reverse(head.next);
        head.next.next = head;
        head.next = null;
        return p;
    }
}