/*
https://leetcode.com/problems/largest-local-values-in-a-matrix/submissions/1255765424/

Time: O(N²)
Space O(N²)
*/

public class Solution {
    public int[][] LargestLocal(int[][] grid) {
        int size = grid.Length;

        int[][] result = new int[size-2][];

        for (int row = 0; row < size - 2; row++) {
            result[row] = new int[size - 2];
            for (int column = 0; column < size - 2; column++) {
                result[row][column] = GetLocalMax(grid, row, column);
            }
        }
        return result;
    }

    public int GetLocalMax(int[][] grid, int currentRow, int currentColumn){
        int max = 0;
        for(int row=currentRow;row<currentRow + 3;row++){
            for(int column=currentColumn;column<currentColumn + 3;column++){
                max = Math.Max(max, grid[row][column]);
            }
        }
        return max;
    }
}