/*
https://leetcode.com/problems/remove-nth-node-from-end-of-list/submissions/1210322088/

Time: O(N)
Space: O(1)
*/

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        if(head==null){
            return head;
        }
        var dummy = new ListNode(0);
        dummy.next = head;

        var first = dummy;
        var second = dummy;

        for(int i=0;i<=n;i++){
            second = second.next;
        }

        while(second != null){
            second = second.next;
            first = first.next;
        }

        first.next = first.next.next;

        return dummy.next;
    }
}