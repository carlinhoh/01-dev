/*
https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k/submissions/1454940160/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public int ShortestSubarray(int[] nums, int k) {
        int n = nums.Length;
        Span<long> prefixSums = stackalloc long[n + 1]; 
        prefixSums[0] = 0;
        long sum = 0;
        for (int i = 1; i <= n; i++) {
            sum += nums[i - 1];
            prefixSums[i] = sum;
        }

        int minLength = n + 1;
        LinkedList<int> deque = new LinkedList<int>(); 

        for (int i = 0; i <= n; i++) {
            while (deque.Count > 0 && prefixSums[i] - prefixSums[deque.First.Value] >= k) {
                minLength = Math.Min(minLength, i - deque.First.Value);
                deque.RemoveFirst();
            }

            while (deque.Count > 0 && prefixSums[i] <= prefixSums[deque.Last.Value]) {
                deque.RemoveLast();
            }

            deque.AddLast(i);
        }

        return minLength <= n ? minLength : -1;
    }
}