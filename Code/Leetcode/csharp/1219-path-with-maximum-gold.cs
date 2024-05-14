/*
https://leetcode.com/problems/path-with-maximum-gold/submissions/1258230888/

Time: O(n * m * 4^g), where g is the number of gold cels
Space: O(g)
*/

public class Solution {
    int max = 0;
    int[][] directions = new int[][] {
        new int[] {-1, 0}, 
        new int[] {1, 0},  
        new int[] {0, -1}, 
        new int[] {0, 1}   
    };
    public int GetMaximumGold(int[][] grid) {
        for(int i=0;i<grid.Length;i++){
            for(int j=0;j<grid[0].Length;j++){
                if(grid[i][j] > 0){
                    Dfs(grid, i, j, 0);
                }
            }
        }
        return max;
    }
    private void Dfs(int[][] grid, int r, int c, int gold){
        if(r < 0 || c < 0 || r >= grid.Length || c >=  grid[0].Length || grid[r][c] ==  0){
            max = Math.Max(gold, max);
            return;
        }

        int currentGold = grid[r][c];
        gold += currentGold;

        grid[r][c] = 0;

        foreach (var direction in directions) {
            int newRow = r + direction[0];
            int newCol = c + direction[1];
            Dfs(grid, newRow, newCol, gold);
        }

        grid[r][c] = currentGold;
    }
}