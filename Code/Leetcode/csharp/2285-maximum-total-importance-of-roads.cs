/*
https://leetcode.com/problems/maximum-total-importance-of-roads/submissions/1303365700/

Time: O(n * log(n))
Space: O(n)
*/
public class Solution
{
    public long MaximumImportance(int n, int[][] roads)
    {
        long[] degree = new long[n];

        foreach (var edge in roads)
        {
            degree[edge[0]]++;
            degree[edge[1]]++;
        }

        Array.Sort(degree);

        long value = 1;
        long totalImportance = 0;
        foreach (long d in degree)
        {
            totalImportance += (value * d);
            value++;
        }

        return totalImportance;
    }
}
