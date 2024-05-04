/*
https://leetcode.com/problems/interval-list-intersections/submissions/1249333203/

Time: O(n+m)
Space: O(n+m)
*/

public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        if (firstList.Length == 0 || secondList.Length == 0) {
            return new int[0][];
        }

        if (firstList[firstList.Length - 1][1] < secondList[0][0] || secondList[secondList.Length - 1][1] < firstList[0][0]) {
            return new int[0][];
        }

        List<int[]> result = new List<int[]>();

        int i = 0, j = 0;
        while (i < firstList.Length && j < secondList.Length) {
            
            int startMax = Math.Max(firstList[i][0], secondList[j][0]);
            int endMin = Math.Min(firstList[i][1], secondList[j][1]);

            if (startMax <= endMin) {
                result.Add(new int[] { startMax, endMin });
            }

            if (firstList[i][1] < secondList[j][1]) {
                i++;
            } else {
                j++;
            }
        }

        return result.ToArray();
    }
}
