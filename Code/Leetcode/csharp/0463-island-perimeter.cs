/*
https://leetcode.com/problems/island-perimeter/submissions/1274549529/

Time: O(n * m)
Space: O(1)
*/
public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int perimeter = 0;
        for(int row=0;row<grid.Length;row++){
            for(int column=0;column<grid[0].Length;column++){
                if(grid[row][column] == 1){
                    perimeter += 4;
                    
                    if(row>0 && grid[row-1][column] == 1){
                        perimeter -= 2;
                    }
                    if(column>0 && grid[row][column-1] == 1){
                        perimeter -= 2;
                    }
                }
            }
        }
        return perimeter;
    }
}