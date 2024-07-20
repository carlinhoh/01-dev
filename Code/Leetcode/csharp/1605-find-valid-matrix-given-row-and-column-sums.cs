/*
https://leetcode.com/problems/find-valid-matrix-given-row-and-column-sums/submissions/1327802014/

Time: O(n * m)
Space: O(1)
*/
public class Solution
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        int N = rowSum.Length;
        int M = colSum.Length;

        int[][] origMatrix = new int[N][];
        for (int k = 0; k < N; k++)
        {
            origMatrix[k] = new int[M];
        }

        int i = 0, j = 0;

        while (i < N && j < M)
        {
            origMatrix[i][j] = Math.Min(rowSum[i], colSum[j]);

            rowSum[i] -= origMatrix[i][j];
            colSum[j] -= origMatrix[i][j];

            if (rowSum[i] == 0)
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return origMatrix;
    }
}
