/*
https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/submissions/1310915511/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        int prevValue = 0, currValue = 0, nextValue = 0;
        int minDistance = int.MaxValue;
        int currentIndex = 1;
        int[] result = new int[] { -1, -1 };
        int? firstCriticalIndex = null;
        int? prevCriticalIndex = null;

        while (head != null) {
            prevValue = currValue;
            currValue = nextValue;
            nextValue = head.val;

            if (prevValue != 0 && currValue != 0 && nextValue != 0 && ((prevValue > currValue && currValue < nextValue) || (prevValue < currValue && currValue > nextValue))) {
                if (firstCriticalIndex == null) {
                    firstCriticalIndex = currentIndex;
                } else {
                    minDistance = Math.Min(minDistance, currentIndex - prevCriticalIndex.Value);
                    result = new int[] { minDistance, currentIndex - firstCriticalIndex.Value };
                }
                prevCriticalIndex = currentIndex;
            }

            currentIndex++;
            head = head.next;
        }

        return result;
    }
}