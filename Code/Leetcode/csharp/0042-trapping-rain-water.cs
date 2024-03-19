/*
https://leetcode.com/problems/trapping-rain-water/submissions/1208278154/

Time: O(N)
Space: O(1)
*/
public class Solution {
    public int Trap(int[] height) {
         if (height.Length == 0)
            return 0;
        
        int left = 0, right = height.Length-1;
        
        int lMax = height[left], rMax = height[right];
        
        int amountWater = 0;
        
        while(left<right){
            if(lMax<rMax){
                left++;
                lMax = Math.Max(lMax, height[left]);
                amountWater += lMax - height[left];
               
            }
            else{
                right--;
                rMax = Math.Max(rMax, height[right]);
                amountWater += rMax - height[right];
            }
        }
        
        return amountWater;
    }
}