/*
https://leetcode.com/problems/average-waiting-time/submissions/1315699614/

Time: O(n)
Space: O(1)
*/
public class Solution
{
    public double AverageWaitingTime(int[][] customers)
    {
        int nextIdleTime = 0;
        long netWaitTime = 0;

        for (int i = 0; i < customers.Length; i++)
        {
        
            nextIdleTime = Math.Max(customers[i][0], nextIdleTime) + customers[i][1];

            netWaitTime += nextIdleTime - customers[i][0];
        }

        double averageWaitTime = (double)netWaitTime / customers.Length;
        return averageWaitTime;
    }
}
