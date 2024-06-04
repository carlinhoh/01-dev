/*
https://leetcode.com/problems/merge-in-between-linked-lists/submissions/1276872222/

Time: O(n + m)
Space: O(1)
*/

public class Solution {
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2) {
        ListNode start = null;
        ListNode end = list1;

        for(int i=0;i<b;i++){
            if(i == a - 1){
                start = end;
            }
            end = end.next;
        }

        start.next = list2;

        while(list2.next != null){
            list2 = list2.next;
        }

        list2.next = end.next;

        return list1;
    }
}