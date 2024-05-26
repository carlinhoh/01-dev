/*
https://leetcode.com/problems/monotonic-array/submissions/1268156626/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public bool IsMonotonic(int[] nums) {
        bool increasing = true;
        bool decreasing = true;
        
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[i - 1]) {
                decreasing = false;
            }
            if (nums[i] < nums[i - 1]) {
                increasing = false;
            }
        }
        
        return increasing || decreasing;
    }
}