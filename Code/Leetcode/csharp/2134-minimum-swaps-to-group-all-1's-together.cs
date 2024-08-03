/*
https://leetcode.com/problems/minimum-swaps-to-group-all-1s-together-ii/submissions/1342424422/

Time: O(n)
Space: O(1)
*/
public class Solution
{
    public int MinSwaps(int[] nums)
    {
        int minimumSwaps = int.MaxValue;
        int totalOnes = 0;
        
        foreach (int num in nums)
        {
            totalOnes += num;
        }

        int onesCount = nums[0];
        int end = 0;

        for (int start = 0; start < nums.Length; ++start)
        {
            if (start != 0)
            {
                onesCount -= nums[start - 1];
            }

            while (end - start + 1 < totalOnes)
            {
                end++;
                onesCount += nums[end % nums.Length];
            }

            minimumSwaps = Math.Min(minimumSwaps, totalOnes - onesCount);
        }

        return minimumSwaps;
    }
}
