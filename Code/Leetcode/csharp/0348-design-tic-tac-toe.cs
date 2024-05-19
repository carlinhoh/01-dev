/*
https://leetcode.com/problems/design-tic-tac-toe/submissions/1261712308/

Time: O(1)
Space: O(n)
*/
public class TicTacToe {
    int[] rows;
    int[] columns;
    int diagonal = 0;
    int secDiagonal = 0;
    int size;

    public TicTacToe(int n) {
        rows = new int[n];
        columns = new int[n];
        size = n;
    }
    
    public int Move(int row, int col, int player) {
        int toAdd = player == 1 ? 1 : -1;

        rows[row] += toAdd;
        columns[col] += toAdd;

        if (row == col) {
            diagonal += toAdd;
        }

        if (row + col == size - 1) {
            secDiagonal += toAdd;
        }

        if (Math.Abs(rows[row]) == size || Math.Abs(columns[col]) == size || Math.Abs(diagonal) == size || Math.Abs(secDiagonal) == size) {
            return player;
        }

        return 0;
    }
}