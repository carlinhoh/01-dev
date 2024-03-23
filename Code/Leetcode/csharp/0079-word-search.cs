/*
https://leetcode.com/problems/word-search/submissions/1211788900/

Time: O(N*3^L), where N is the size of board and L the size of word
Space: O(L)
*/
public class Solution {
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
    public bool Exist(char[][] board, string word) {
        int m = board.Length;
        int n = board[0].Length;
        for(int row=0;row<m;row++){
            for(int col=0;col<n;col++){
                if(board[row][col]==word[0]){
                    if(CheckWordInBoard(row,col,word,board,0)){
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool CheckWordInBoard(int row, int col, string word, char[][] board, int wordIndex){
        if(row < 0 || col < 0 || row >= board.Length || col >= board[0].Length){
            return false;
        }
        if(word[wordIndex] == board[row][col]){
            char temp = board[row][col];
            board[row][col] = '#';

            if(wordIndex == word.Length-1){
                return true;
            }

            bool found =  CheckWordInBoard(row-1, col, word, board, wordIndex+1) ||
                          CheckWordInBoard(row+1, col, word, board, wordIndex+1) ||
                          CheckWordInBoard(row, col-1, word, board, wordIndex+1) ||
                          CheckWordInBoard(row, col+1, word, board, wordIndex+1);

            board[row][col] = temp;

            return found;                          
        }
        else return false;
    }
}