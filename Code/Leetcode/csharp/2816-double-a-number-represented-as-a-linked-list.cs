/*
Recursive https://leetcode.com/problems/double-a-number-represented-as-a-linked-list/submissions/1251870929/
Time: O(n)
Space: O(n)

Iterative https://leetcode.com/problems/double-a-number-represented-as-a-linked-list/submissions/1251879534/
Time: O(n)
Space: O(1)
*/
public class Solution {
    public ListNode DoubleIt(ListNode head) {
        var dummy = new ListNode(0, head);
        var prev = dummy;
        while(head != null){
            int currVal = head.val * 2;
            if( currVal >= 10) prev.val++;
            head.val = currVal % 10;
            prev = head;
            head = head.next;
        }
        return dummy.val == 0 ? dummy.next : dummy;
    }
}
public class Solution {
    int carry = 0;
    public ListNode DoubleIt(ListNode head) {
        Dfs(head);

        if(carry>0){
            var dummyHead = new ListNode(1, head);
            return dummyHead;
        }
        
        return head;
    }

    public void Dfs(ListNode head){
        if(head == null){
            return;
        }

        Dfs(head.next);
        int curr = (head.val * 2) + carry;
        head.val = curr % 10;
        if(curr != head.val) carry = 1;
        else carry = 0;
    }
}