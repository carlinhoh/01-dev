/*
https://leetcode.com/problems/magnetic-force-between-two-balls/submissions/1294827815/

Time: O(nlog((n * k)/m))
Space: O(log(n))
*/
public class Solution
{
    private bool CanPlaceBalls(int x, int[] position, int m)
    {
        int prevBallPos = position[0];
        int ballsPlaced = 1;

        for (int i = 1; i < position.Length && ballsPlaced < m; ++i)
        {
            int currPos = position[i];
            if (currPos - prevBallPos >= x)
            {
                ballsPlaced += 1;
                prevBallPos = currPos;
            }
        }
        return ballsPlaced == m;
    }

    public int MaxDistance(int[] position, int m)
    {
        int answer = 0;
        int n = position.Length;
        Array.Sort(position);

        int low = 1;
        int high = (int)Math.Ceiling(position[n - 1] / (m - 1.0));
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (CanPlaceBalls(mid, position, m))
            {
                answer = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return answer;
    }
}
