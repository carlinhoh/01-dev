/*
https://leetcode.com/problems/find-the-town-judge/submissions/1324633454/

Time: O(E), Where E is the number of edges
Space: O(N)
*/
public class Solution {
    public int FindJudge(int N, int[][] trust)
    {
        if (trust.Length < N - 1)
        {
            return -1;
        }

        int[] trustScores = new int[N + 1];

        foreach (var relation in trust)
        {
            trustScores[relation[0]]--;
            trustScores[relation[1]]++;
        }

        for (int i = 1; i <= N; i++)
        {
            if (trustScores[i] == N - 1)
            {
                return i;
            }
        }
        return -1;
    }
}