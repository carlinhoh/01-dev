/*
#blind-75
#neetcode-150
https://leetcode.com/problems/search-in-rotated-sorted-array/submissions/1206634796/

Time:O(logN)
Space:O(1) 
*/

public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0;
        int right = nums.Length-1;    

        while(left<=right){
            int mid = left + (right - left)/2;
            
            if(nums[mid]==target){
                return mid;
            }
            else if(nums[mid] >= nums[left]){//left side
                if(target>=nums[left] && target<nums[mid]){
                    right = mid-1;
                }
                else{
                    left = mid + 1;
                }
            }
            else{
                if(target>nums[mid] && target <= nums[right]){
                    left = mid +1;
                }
                else{
                    right= mid-1;
                }
            }
        }

        return -1;
    }
}