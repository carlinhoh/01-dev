/*
BFS https://leetcode.com/problems/number-of-islands/submissions/1275532494/

Time: O(n * m)
Space: O(Min(n,m))

DFS https://leetcode.com/problems/number-of-islands/submissions/1275506943/

Time: O(n * m)
Space: O(n*m)
*/
public class Solution {
    int[][] directions = new int[][] { new int[2] {0, 1}, new int[2] {0, -1}, new int[2] {1, 0}, new int[2] {-1, 0} };
    public int NumIslands(char[][] grid) {
        int rows = grid.Length;
        int columns = grid[0].Length;
        int islandCount = 0;

        for(int i=0;i<rows;i++){
            for(int j=0;j<columns;j++){
                if(grid[i][j] == '1'){
                    islandCount++;
                    Queue<(int row, int column)> q = new();
                    q.Enqueue((i, j));
                    while(q.Any()){
                        var current = q.Dequeue();
                        grid[current.row][current.column] = '0';
                        GetValidNeighbors(grid, q, current.row, current.column);
                    }
                }
            }
        }

        return islandCount;
    }

    private void GetValidNeighbors(char[][] grid, Queue<(int row, int column)> q, int row, int column){
        foreach(int[] direction in directions){
            int newRow = row + direction[0];
            int newColumn = column + direction[1];
            if(newRow >=0 && newColumn >=0 && newColumn < grid[0].Length && newRow < grid.Length && grid[newRow][newColumn] == '1'){
                grid[newRow][newColumn] = '0';
                q.Enqueue((newRow, newColumn));
            }
        }
    }
}

public class Solution {
    public int NumIslands(char[][] grid) {
        int count = 0;
        int rows = grid.Length;
        int columns = grid[0].Length;

        for(int i=0;i<rows;i++){
            for(int j=0;j<columns;j++){
                if(grid[i][j] == '1'){
                    Dfs(grid, i, j);
                    count++;
                }
            }
        }

        return count;
    }

    private void Dfs(char[][] grid, int row, int column){
        if(row < 0 || column < 0 || row >= grid.Length || column >= grid[0].Length || grid[row][column] != '1'){
            return;
        }
        grid[row][column] = '0';

        Dfs(grid, row - 1, column);
        Dfs(grid, row, column - 1);
        Dfs(grid, row + 1, column);
        Dfs(grid, row, column + 1);
    }
}