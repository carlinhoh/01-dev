/*
https://leetcode.com/problems/copy-list-with-random-pointer/submissions/1276988478/

Time: O(n)
Space: O(n)
*/

public class Solution {
    Dictionary<Node, Node> visitedList = new Dictionary<Node, Node>();
    public Node CopyRandomList(Node head)
        {

            if(head == null)
            {
                return null;
            }

            if (visitedList.ContainsKey(head))
            {
                return visitedList[head];
            }

            Node copiedNode = new Node(head.val);

            visitedList.Add(head, copiedNode);

            copiedNode.next = CopyRandomList(head.next);
            copiedNode.random= CopyRandomList(head.random);


            return copiedNode;
        }
}