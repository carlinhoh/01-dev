/*
https://leetcode.com/problems/longest-increasing-path-in-a-matrix/submissions/1250463819/

Time: O(m*n)
Space: O(m*n)
*/

public class Solution {
    Dictionary<(int, int), int> memo;
    int maxValue = 0;

    public int LongestIncreasingPath(int[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) {
            return 0;
        }
        memo = new Dictionary<(int, int), int>();
        for (int row = 0; row < matrix.Length; row++) {
            for (int column = 0; column < matrix[0].Length; column++) {
                maxValue = Math.Max(maxValue, Dfs(matrix, row, column, -1));
            }
        }

        return maxValue;
    }

    private int Dfs(int[][] matrix, int row, int column, int prevVal) {
        if (row < 0 || column < 0 || row >= matrix.Length || column >= matrix[0].Length 
            || matrix[row][column] <= prevVal) {
            return 0;
        }

        if (memo.ContainsKey((row, column))) {
            return memo[(row, column)];
        }

        int res = 1; // Base case: every cell is a path of length 1 by itself.
        res = Math.Max(res, 1 + Dfs(matrix, row + 1, column, matrix[row][column]));
        res = Math.Max(res, 1 + Dfs(matrix, row - 1, column, matrix[row][column]));
        res = Math.Max(res, 1 + Dfs(matrix, row, column + 1, matrix[row][column]));
        res = Math.Max(res, 1 + Dfs(matrix, row, column - 1, matrix[row][column]));

        memo[(row, column)] = res;
        return res;
    }
}
