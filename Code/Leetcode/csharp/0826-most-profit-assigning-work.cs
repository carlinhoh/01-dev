/*
https://leetcode.com/problems/most-profit-assigning-work/submissions/1292652998/

Time: O(n + m + maxAbility)
Space: O(maxAbility)
*/
public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker){
        // Find maximum ability in the worker array.
        int maxAbility = worker.Max();
        int[] jobs = new int[maxAbility + 1];

        // Fill the jobs array with the maximum profit for each difficulty level.
        for (int i = 0; i < difficulty.Length; i++){
            if (difficulty[i] <= maxAbility)
            {
                jobs[difficulty[i]] = Math.Max(jobs[difficulty[i]], profit[i]);
            }
        }

        // Take maxima of prefixes.
        for (int i = 1; i <= maxAbility; i++){
            jobs[i] = Math.Max(jobs[i], jobs[i - 1]);
        }

        int netProfit = 0;
        // Sum up the maximum profit each worker can achieve based on their ability.
        foreach (int ability in worker){
            netProfit += jobs[ability];
        }

        return netProfit;
    }
}