/*
https://leetcode.com/problems/merge-k-sorted-lists/submissions/1210340416/

Time: O(Nlogk), where k is the number of linked lists.
Space: O(k)

Merge Solution
Time: O(NlogK)
Space: O(1)
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

public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists.Length == 0){
            return null;
        }

        int interval = 1;
        while (interval < lists.Length){
            for (int i = 0; i + interval < lists.Length; i += interval * 2){
                lists[i] = Merge2Lists(lists[i], lists[i + interval]);
            }
            interval *= 2;
        }

        return lists[0];
    }

    public ListNode Merge2Lists(ListNode l1, ListNode l2){
        ListNode dummy = new ListNode(0);
        ListNode result = dummy;
        while(l1 != null && l2 != null){
            if(l1.val > l2.val){
                dummy.next = l2;
                dummy = dummy.next;
                l2 = l2.next;
            }
            else{
                dummy.next = l1;
                dummy = dummy.next;
                l1 = l1.next;
            }
        }
        
        dummy.next = l1 ?? l2;
        
        return result.next;
    }
}