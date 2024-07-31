/*
https://leetcode.com/problems/filling-bookcase-shelves/submissions/1340048413/

Time:  O(n * w) where w is the shelfWidth
Space: O(n)
*/

public class Solution
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        int[] dp = new int[books.Length + 1];

        dp[0] = 0;
        dp[1] = books[0][1];

        for (int i = 2; i <= books.Length; i++)
        {
            int remainingShelfWidth = shelfWidth - books[i - 1][0];
            int maxHeight = books[i - 1][1];
            dp[i] = books[i - 1][1] + dp[i - 1];

            int j = i - 1;
            while (j > 0 && remainingShelfWidth - books[j - 1][0] >= 0)
            {
                maxHeight = Math.Max(maxHeight, books[j - 1][1]);
                remainingShelfWidth -= books[j - 1][0];
                dp[i] = Math.Min(dp[i], maxHeight + dp[j - 1]);
                j--;
            }
        }

        return dp[books.Length];
    }
}
