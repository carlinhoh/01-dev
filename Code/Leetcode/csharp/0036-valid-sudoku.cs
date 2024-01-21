/*
#neetcode-150
https://leetcode.com/problems/valid-sudoku/submissions/1153027340/

Time: O(N²)
Space: O(N²)
*/

public class Solution {
    public bool IsValidSudoku(char[][] board) {
        for(int i=0;i<board.Length;i++){
            if(!CheckLine(board, i)){
                return false;
            }
            if(!CheckColumn(board, i)){
                return false;
            }
        }
        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                if(!CheckGrid(board,3*i,3*j)){
                    return false;
                }
            }
        }
        return true;
    }
    private bool CheckLine(char[][] board, int line){
        HashSet<char> lines = new();
        for(int i=0;i<9;i++){
            if(board[line][i] == '.') continue;
            if(!lines.Add(board[line][i])){
                return false;
            }
        }
        return true;
    }
    private bool CheckColumn(char[][] board, int column){
        HashSet<int> columns = new();
        for(int i=0;i<9;i++){
            if(board[i][column]== '.') continue;
            if(!columns.Add(board[i][column])){
                return false;
            }
        }
        return true;
    }
     private bool CheckGrid(char[][] board, int x, int y){
        HashSet<int> grid = new();
        for(int i=0;i<3;i++){
            for(int j=0;j<3;j++){
                if(board[i+x][j+y]== '.') continue;
                if(!grid.Add(board[i+x][j+y])){
                    return false;
                }
            }
        }
        return true;
    }
}