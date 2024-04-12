/*
https://leetcode.com/problems/coin-change/submissions/1229947214/

Time: O(k*N), where k is the amount 
Space: O(k)
*/
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int n = coins.Length-1;
        int[] dp = Enumerable.Repeat(amount+1, amount+1).ToArray();
        dp[0]=0;
        for(int i=1;i<amount+1;i++){
            for(int j=0;j<=n;j++){
                if((i-coins[j])>=0){
                    dp[i] = Math.Min(dp[i], 1+dp[i-coins[j]]);
                }
            }
        }
        return dp[amount] == amount+1 ? -1: dp[amount];
    }
}