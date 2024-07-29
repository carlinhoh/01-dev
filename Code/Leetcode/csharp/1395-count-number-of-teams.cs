/*
https://leetcode.com/problems/count-number-of-teams/submissions/1337827515/

Time: O(n * log(maxRating))
Space: O(maxRating)
*/
public class Solution
{
    public int NumTeams(int[] rating)
    {
        int maxRating = 0;
        foreach (int r in rating)
        {
            maxRating = Math.Max(maxRating, r);
        }

        int[] leftBIT = new int[maxRating + 1];
        int[] rightBIT = new int[maxRating + 1];

        foreach (int r in rating)
        {
            UpdateBIT(rightBIT, r, 1);
        }

        int teams = 0;
        foreach (int currentRating in rating)
        {
            UpdateBIT(rightBIT, currentRating, -1);

            int smallerRatingsLeft = GetPrefixSum(leftBIT, currentRating - 1);
            int smallerRatingsRight = GetPrefixSum(rightBIT, currentRating - 1);
            int largerRatingsLeft = GetPrefixSum(leftBIT, maxRating) - GetPrefixSum(leftBIT, currentRating);
            int largerRatingsRight = GetPrefixSum(rightBIT, maxRating) - GetPrefixSum(rightBIT, currentRating);

            teams += (smallerRatingsLeft * largerRatingsRight);
            teams += (largerRatingsLeft * smallerRatingsRight);

            UpdateBIT(leftBIT, currentRating, 1);
        }

        return teams;
    }

    private void UpdateBIT(int[] BIT, int index, int value)
    {
        while (index < BIT.Length)
        {
            BIT[index] += value;
            index += index & (-index);
        }
    }

    private int GetPrefixSum(int[] BIT, int index)
    {
        int sum = 0;
        while (index > 0)
        {
            sum += BIT[index];
            index -= index & (-index);
        }
        return sum;
    }
}
