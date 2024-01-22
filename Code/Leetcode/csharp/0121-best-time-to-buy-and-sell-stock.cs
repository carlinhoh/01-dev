/*
#blind-75
#neetcode-150
https://leetcode.com/problems/best-time-to-buy-and-sell-stock/submissions/1153967507/
*/

public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0;
        int minPrice = prices[0];

        for (int i = 1; i < prices.Length; i++) {
            int currPrice = prices[i];
            minPrice = Math.Min(minPrice, currPrice);
            maxProfit = Math.Max(maxProfit, currPrice - minPrice);
        }
        return maxProfit;
    }
}