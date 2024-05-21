/* 

Two Pointers https://leetcode.com/problems/intersection-of-two-linked-lists/submissions/1264328315/

Time: O(n + m)
Space: O(1)

HashSet https://leetcode.com/problems/intersection-of-two-linked-lists/submissions/1264318949/

Time: O(n + m)
Space: O(m)

flagging nodes https://leetcode.com/problems/intersection-of-two-linked-lists/submissions/1264325467/

Time: O(n + m)
Space: O(1)

*/
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        HashSet<ListNode> nodesInB = new();
        while(headB != null){
            nodesInB.Add(headB);
            headB = headB.next;
        }

        while(headA != null){
            if(nodesInB.Contains(headA)){
                return headA;
            }
            headA = headA.next;
        }

        return null;
    }
}

public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        if (headA == null || headB == null) return null;

        var p1 = headA;
        while (p1 != null) {
            p1.val = -p1.val;
            p1 = p1.next;
        }

        var p2 = headB;
        while (p2 != null && p2.val > 0) {
            p2 = p2.next;
        }

        if (p2 == null) {
            p1 = headA;
            while (p1 != null) {
                p1.val = Math.Abs(p1.val);
                p1 = p1.next;
            }
            return null;
        }

        var res = p2;
        p1 = headA;
        while (p1 != null) {
            p1.val = Math.Abs(p1.val); 
            p1 = p1.next;
        }

        return res;
    }
}