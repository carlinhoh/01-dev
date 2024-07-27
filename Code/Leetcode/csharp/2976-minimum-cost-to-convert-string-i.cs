/*
https://leetcode.com/problems/minimum-cost-to-convert-string-i/submissions/1335558536/

Time: O(n + m)
Space: O(1)
*/
public class Solution
{
    public long MinimumCost(
        string source,
        string target,
        char[] original,
        char[] changed,
        int[] cost
    )
    {
        long totalCost = 0;

        long[,] minCost = new long[26, 26];
        for (int i = 0; i < 26; ++i)
        {
            for (int j = 0; j < 26; ++j)
            {
                minCost[i, j] = int.MaxValue;
            }
        }

        for (int i = 0; i < original.Length; ++i)
        {
            int startChar = original[i] - 'a';
            int endChar = changed[i] - 'a';
            minCost[startChar, endChar] = Math.Min(
                minCost[startChar, endChar],
                (long)cost[i]
            );
        }

        for (int k = 0; k < 26; ++k)
        {
            for (int i = 0; i < 26; ++i)
            {
                for (int j = 0; j < 26; ++j)
                {
                    minCost[i, j] = Math.Min(
                        minCost[i, j],
                        minCost[i, k] + minCost[k, j]
                    );
                }
            }
        }

        for (int i = 0; i < source.Length; ++i)
        {
            if (source[i] == target[i])
            {
                continue;
            }
            int sourceChar = source[i] - 'a';
            int targetChar = target[i] - 'a';

            if (minCost[sourceChar, targetChar] >= int.MaxValue)
            {
                return -1;
            }
            totalCost += minCost[sourceChar, targetChar];
        }

        return totalCost;
    }
}
