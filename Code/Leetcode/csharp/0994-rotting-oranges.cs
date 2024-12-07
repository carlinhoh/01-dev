/*
https://leetcode.com/problems/rotting-oranges/submissions/1472847557/

Time: O(M*N)
Space: O(M*N)
*/
public class Solution {
    int[][] directions = new int[][] {
        new int[]{1,0},
        new int[]{-1,0},
        new int[]{0,1},
        new int[]{0,-1}
    };

    public int OrangesRotting(int[][] grid) {
        if(grid==null || grid.Length == 0) return -1;

        Queue<(int x, int y)> queue = new();
        int rows = grid.Length;
        int cols = grid[0].Length;
        int freshOranges = 0;

        for(int r=0;r<rows;r++){
            for(int c=0;c<cols;c++){
                if(grid[r][c] == 2){
                    queue.Enqueue((r, c));
                }
                else if(grid[r][c] == 1){
                    freshOranges++;
                }
            }
        }

        if(freshOranges == 0){
            return 0;
        }

        int layers =0;

        while(queue.Count > 0){
            layers++;
            int level = queue.Count;
            for(int i=0;i<level;i++){
                var coord = queue.Dequeue();
                foreach(var direction in directions){
                    var x = coord.x + direction[0];
                    var y = coord.y + direction[1];
                    if(x < 0 || y < 0 || x >= rows || y >= cols || grid[x][y] == 0 || grid[x][y] == 2){ continue; } 
                    grid[x][y] = 2;
                    queue.Enqueue((x, y));
                    freshOranges--;
                }
            }
        }

        return freshOranges == 0 ?  layers -1 : -1;

    }

    
}
