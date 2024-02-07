/*
https://leetcode.com/problems/middle-of-the-linked-list/submissions/1168337341/

Time: O(N)
Space: O(1)
*/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MiddleNode(ListNode head) {
       var slow = head;
       var fast = head;
       while(fast!=null && fast.next!=null){
           slow = slow.next;
           fast = fast.next.next;
       }
       return slow;
    }
}