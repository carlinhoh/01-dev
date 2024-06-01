/*
Busca binária + DFS https://leetcode.com/problems/path-with-minimum-effort/submissions/1274273424/

Time: O(m * n * log(maxheight))
Space: O(m * n)

*/
public class Solution {
    private static readonly int[][] Directions = {
        new int[] {1, 0}, new int[] {-1, 0}, 
        new int[] {0, 1}, new int[] {0, -1}
    };
    private int rows, cols;

    public int MinimumEffortPath(int[][] heights) {
        rows = heights.Length;
        cols = heights[0].Length;
        
        int left = 0, right = 1000000, result = right;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (CanReachDestination(heights, mid)) {
                result = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return result;
    }

    private bool CanReachDestination(int[][] heights, int maxEffort) {
        var visited = new bool[rows, cols];
        return Dfs(heights, 0, 0, visited, maxEffort);
    }

    private bool Dfs(int[][] heights, int x, int y, bool[,] visited, int maxEffort) {
        if (x == rows - 1 && y == cols - 1) return true;
        visited[x, y] = true;

        foreach (var direction in Directions) {
            int newX = x + direction[0], newY = y + direction[1];
            if (IsValid(newX, newY) && !visited[newX, newY] &&
                Math.Abs(heights[newX][newY] - heights[x][y]) <= maxEffort) {
                if (Dfs(heights, newX, newY, visited, maxEffort)) return true;
            }
        }
        return false;
    }

    private bool IsValid(int x, int y) {
        return x >= 0 && x < rows && y >= 0 && y < cols;
    }
}
