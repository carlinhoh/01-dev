/*
https://leetcode.com/problems/minimum-area-rectangle/submissions/1289427360/

Time: O(n^2)
Space: O(n)
*/

public class Solution {
    public int MinAreaRect(int[][] points) {

        var pointSet = new HashSet<(int, int)>();
        foreach (var point in points)
        {
            pointSet.Add((point[0], point[1]));
        }

        int minArea = int.MaxValue;
        int n = points.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int x1 = points[i][0];
                int y1 = points[i][1];
                int x2 = points[j][0];
                int y2 = points[j][1];

                if (x1 != x2 && y1 != y2)
                {
                    if (pointSet.Contains((x1, y2)) && pointSet.Contains((x2, y1)))
                    {
                        int area = Math.Abs(x2 - x1) * Math.Abs(y2 - y1);
                        minArea = Math.Min(minArea, area);
                    }
                }
            }
        }
        return minArea == int.MaxValue ? 0 : minArea;
    }
}