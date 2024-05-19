/*
https://leetcode.com/problems/making-a-large-island/submissions/1262558678/

Time: O(N²)
Space: O(N²)
*/

public class Solution {
private int[][] directions = new int[4][] {
        new int[] {0, 1}, new int[] {0, -1}, new int[] {1, 0}, new int[] {-1, 0}
    };

    public int LargestIsland(int[][] grid) {
        int n = grid.Length;
        Dictionary<int, int> islandColorToSize = new(){ {0,0} };
        int colorIdx = 2;// first color

        //Paint islands 
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 1) {
                    int islandSize = PaintIsland(grid, i, j, colorIdx);
                    islandColorToSize[colorIdx++] = islandSize;
                }
            }
        }

        int maxIslandSize = islandColorToSize.Values.Max();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 0) {
                    HashSet<int> seenIslands = new HashSet<int>();
                    foreach (var dir in directions) {
                        int newRow = i + dir[0], newColumn = j + dir[1];
                        if (newRow >= 0 && newRow < n && newColumn >= 0 && newColumn < n && grid[newRow][newColumn] != 0) {
                            seenIslands.Add(grid[newRow][newColumn]);
                        }
                    }

                    int newSize = 1; //start with 1 cause the flip 0 to 1

                    foreach (int id in seenIslands) {
                        if (islandColorToSize.ContainsKey(id)) {
                            newSize += islandColorToSize[id];
                        }
                    }
                    maxIslandSize = Math.Max(maxIslandSize, newSize);
                }
            }
        }
        return maxIslandSize;
    }

    private int PaintIsland(int[][] grid, int row, int column, int color) {
        int n = grid.Length;
        Stack<(int, int)> stack = new Stack<(int, int)>();
        stack.Push((row, column));
        grid[row][column] = color;
        int size = 0;

        while (stack.Count > 0) {
            var (r, c) = stack.Pop();
            size++;
            foreach (var dir in directions) {
                int newRow = r + dir[0], newColumn = c + dir[1];
                if (newRow >= 0 && newRow < n && newColumn >= 0 && newColumn < n && grid[newRow][newColumn] == 1) {
                    grid[newRow][newColumn] = color;
                    stack.Push((newRow, newColumn));
                }
            }
        }

        return size;
    }
}