/*
https://leetcode.com/problems/shortest-path-in-binary-matrix/submissions/1247878324/

Time: O(n)
Space: O(n)
*/
public class Solution {
    int[][] directions = {new int[]{-1,-1}, new int[]{1,-1}, new int[]{0,-1}, new int[]{-1,0}, new int[]{1,0}, new int[]{1,1}, new int[]{-1,1}, new int[]{0,1}};
    public int ShortestPathBinaryMatrix(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        if(grid[m-1][n-1] == 1 || grid[0][0] == 1) return -1;
        if(grid[0][0] == 0 && m == 1 && n == 1) return 1;

        bool[,] visited = new bool[m, n];
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        visited[0, 0] = true;
        int distance = 1;

        while(queue.Count != 0){
            int levelSize = queue.Count;
            for(int k = 0; k < levelSize; k++) {
                var (row, column) = queue.Dequeue();
                foreach(var direction in directions){
                    int newRow = row + direction[0];
                    int newColumn = column + direction[1];
                    if(newRow >= 0 && newColumn >= 0 && newRow < m && newColumn < n && grid[newRow][newColumn] == 0 && !visited[newRow, newColumn]){
                        if(newRow == m-1 && newColumn == n-1) return distance + 1;
                        visited[newRow, newColumn] = true;
                        queue.Enqueue((newRow, newColumn));
                    }
                }
            }
            distance++;
        }
        return -1;
    }
}