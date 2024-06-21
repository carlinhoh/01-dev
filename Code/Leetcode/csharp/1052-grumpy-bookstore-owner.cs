/*
https://leetcode.com/problems/grumpy-bookstore-owner/submissions/1295653147/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        int left = 0;
        int maxUnsatisfiedInWindow = 0;
        int unsatisfiedInWindow = 0;
        int satisfied = 0;

        for(int right=0;right<customers.Length;right++){
            unsatisfiedInWindow += grumpy[right] == 1 ? customers[right] : 0;
            if (right - left + 1 == minutes)
            {
                maxUnsatisfiedInWindow = Math.Max(unsatisfiedInWindow, maxUnsatisfiedInWindow);
                unsatisfiedInWindow -= grumpy[left] == 1 ? customers[left] : 0;
                left++;
            }
            satisfied += grumpy[right] == 1 ? 0 : customers[right];
        }

        return satisfied + maxUnsatisfiedInWindow;
    }
}