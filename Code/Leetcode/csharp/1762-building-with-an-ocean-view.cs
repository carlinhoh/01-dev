/*
https://leetcode.com/problems/buildings-with-an-ocean-view/submissions/1240340548/

Time: O(n)
Space: O(1), If the result array can be ignored.
*/

public class Solution {
    public int[] FindBuildings(int[] heights) {
        int maxHeight = -1;
        List<int> hasOceanView = new();
        
        for(int i = heights.Length-1;i>=0;i--){
            if(heights[i] > maxHeight){
                hasOceanView.Add(i);
                maxHeight = heights[i];
            }
        }

        hasOceanView.Reverse();

        return hasOceanView.ToArray();
    }
}