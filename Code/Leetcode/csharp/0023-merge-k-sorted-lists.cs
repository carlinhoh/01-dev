/*
https://leetcode.com/problems/merge-k-sorted-lists/submissions/1210340416/

Time: O(Nlogk), where k\text{k}k is the number of linked lists.
Space: O(N)
*/

public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists == null){
            return default;
        }

        ListNode dummy = new ListNode(0);
        ListNode head = dummy;

        PriorityQueue<int, int> queue = new();

        foreach(var listNode in lists){
            var curr = listNode;
            while(curr!=null){
                queue.Enqueue(curr.val, curr.val);
                curr = curr.next;
            }
        }

        while(queue.Count>0){
            dummy.next = new ListNode(queue.Dequeue());
            dummy = dummy.next;
        }

        return head.next;
    }
}