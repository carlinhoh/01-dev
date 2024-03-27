/*
https://leetcode.com/problems/binary-search/submissions/1206404889/
Time: O(logN)
Space: O(1)
*/
public class Solution {
    public int Search(int[] nums, int target) {
          int left = 0;
        int right = nums.Length-1;

        while(left<=right){
            int mid = left + (right-left) /2;
            if(nums[mid] == target){
                return mid;
            }
            else if(nums[mid] < target){
                left = mid+1;
            }
            else{
                right = mid-1;
            }
        }

        return -1;
    }
}