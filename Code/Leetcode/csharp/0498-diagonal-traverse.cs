/*
https://leetcode.com/problems/diagonal-traverse/submissions/1250377846/

Time: O(n*m)
Space: O(1)
*/
public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        if (mat == null || mat.Length == 0) return new int[0];

        int n = mat.Length, m = mat[0].Length;
        int[] result = new int[n * m];
        int row = 0, col = 0;
        bool goingUp = true;

        for (int i = 0; i < n * m; i++) {
            result[i] = mat[row][col];

            if (goingUp) {
                if (col == m - 1) {
                    row++; // Hit the right boundary, move down
                    goingUp = false;
                } else if (row == 0) {
                    col++; // Hit the top boundary, move right
                    goingUp = false;
                } else {
                    row--; // Continue moving up
                    col++;
                }
            } else {
                if (row == n - 1) {
                    col++; // Hit the bottom boundary, move right
                    goingUp = true;
                } else if (col == 0) {
                    row++; // Hit the left boundary, move down
                    goingUp = true;
                } else {
                    row++; // Continue moving down
                    col--;
                }
            }
        }
        return result;
    }
}
