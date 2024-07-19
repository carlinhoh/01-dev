/*
https://leetcode.com/problems/lucky-numbers-in-a-matrix/submissions/1326739093/

Time: O(n * m)
Space: O(1)
*/
public class Solution {
    public IList<int> LuckyNumbers(int[][] matrix) {
        int N = matrix.Length, M = matrix[0].Length;

        int rMinMax = int.MinValue;
        for (int i = 0; i < N; i++) {
            int rMin = int.MaxValue;
            for (int j = 0; j < M; j++) {
                rMin = Math.Min(rMin, matrix[i][j]);
            }
            rMinMax = Math.Max(rMinMax, rMin);
        }

        int cMaxMin = int.MaxValue;
        for (int i = 0; i < M; i++) {
            int cMax = int.MinValue;
            for (int j = 0; j < N; j++) {
                cMax = Math.Max(cMax, matrix[j][i]);
            }
            cMaxMin = Math.Min(cMaxMin, cMax);
        }

        if (rMinMax == cMaxMin) {
            return new List<int> { rMinMax };
        }

        return new List<int>();
    }
}
