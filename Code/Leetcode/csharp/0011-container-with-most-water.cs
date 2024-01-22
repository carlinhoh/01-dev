/*
#neetcode-150
https://leetcode.com/problems/container-with-most-water/submissions/1153958169/

Time: O(N)
Space: O(1)
*/
public class Solution {
  public int MaxArea(int[] height)
        {
          int maxArea = 0;
          int left = 0;
          int right = height.Length-1;
      
            while(left<right){
                int currentArea = Math.Min(height[left], height[right]) * (right-left);
                maxArea = Math.Max(maxArea, currentArea);
                if(height[left] > height[right]){
                    right--;
                }
                else left++;
            }
      return maxArea;
    }
}