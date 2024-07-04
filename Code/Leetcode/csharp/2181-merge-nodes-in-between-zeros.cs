/*
https://leetcode.com/problems/merge-nodes-in-between-zeros/submissions/1309875994/

Time: O(n)
Space: O(1)
*/
public class Solution {
   public ListNode MergeNodes(ListNode head) {
        ListNode modify = head.next;
        ListNode nextSum = modify;

        while (nextSum != null) {
            int sum = 0;
            while (nextSum.val != 0) {
                sum += nextSum.val;
                nextSum = nextSum.next;
            }

            modify.val = sum;
            nextSum = nextSum.next;
            modify.next = nextSum;
            modify = modify.next;
        }
        return head.next;
    }
}