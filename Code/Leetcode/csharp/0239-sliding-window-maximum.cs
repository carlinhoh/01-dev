/*
https://leetcode.com/problems/sliding-window-maximum/submissions/1272869450/

Time: O(n)
Space: O(k)
*/
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (nums == null || nums.Length == 0) return new int[0];
        
        int n = nums.Length;
        int[] result = new int[n - k + 1];
        LinkedList<int> deque = new LinkedList<int>();
        int left = 0;
        
        for (int right = 0; right < n; right++) {
            // Remove elements out of the current window
            if (deque.Count > 0 && deque.First.Value < left) {
                deque.RemoveFirst();
            }

            // Remove elements smaller than the current element from the deque
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[right]) {
                deque.RemoveLast();
            }

            // Add the current element's index to the deque
            deque.AddLast(right);

            // If we have formed a valid window
            if (right >= k - 1) {
                result[left] = nums[deque.First.Value];
                left++;
            }
        }

        return result;
    }
}
