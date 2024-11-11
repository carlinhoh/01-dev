/*
https://leetcode.com/problems/burst-balloons/submissions/1449143458/

Time: O(n³)
Space: O(n²)
*/

public class Solution {
    public int MaxCoins(int[] nums) {
         int n = nums.Length;
        int[] extendedNums = new int[n + 2];
        extendedNums[0] = 1;
        extendedNums[n + 1] = 1;
        for (int i = 0; i < n; i++)
        {
            extendedNums[i + 1] = nums[i];
        }
        n += 2;

        int[,] maxCoinsDp = new int[n, n];

        for (int windowSize = 2; windowSize < n; windowSize++)
        {
            for (int leftBoundary = 0; leftBoundary < n - windowSize; leftBoundary++)
            {
                int rightBoundary = leftBoundary + windowSize;
                for (int burstIndex = leftBoundary + 1; burstIndex < rightBoundary; burstIndex++)
                {
                    int coinsCollected = extendedNums[leftBoundary] * extendedNums[burstIndex] * extendedNums[rightBoundary];
                    coinsCollected += maxCoinsDp[leftBoundary, burstIndex] + maxCoinsDp[burstIndex, rightBoundary];
                    maxCoinsDp[leftBoundary, rightBoundary] = Math.Max(maxCoinsDp[leftBoundary, rightBoundary], coinsCollected);
                }
            }
        }

        return maxCoinsDp[0, n - 1];
    }
}