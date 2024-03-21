/*
https://leetcode.com/problems/merge-two-sorted-lists/submissions/1210223360/

Time: O(M+N)
Space: O(1)
*/
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode head = new ListNode(-1);
        ListNode prev = head;

        while(list1!=null && list2!=null){
            if(list1.val <= list2.val){
                prev.next = list1;
                list1 = list1.next;
            }
            else{
                prev.next = list2;
                list2 = list2.next;
            }
            prev = prev.next;
        }

        prev.next = list1 == null ? list2 : list1;

        return head.next;
    }
}

/*

public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if(list1 == null && list2 == null){
            return default;
        }
        else if(list1==null){
            return list2;
        }
        else if(list2== null) return list1;

        else if(list1.val <= list2.val){
            list1.next  = MergeTwoLists(list1.next, list2);
            return list1;
        }
        else{
            list2.next = MergeTwoLists(list1, list2.next);
            return list2;
        }
    }
}
*/