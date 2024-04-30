/*
https://leetcode.com/problems/find-peak-element/submissions/1246008896/
Time: O(logn)
SpacE: O(1)
*/
public class Solution {
    public int FindPeakElement(int[] nums) {
        int left = 0;
        int right = nums.Length-1;

        while(left<right){
            int mid = (left + right) /2;

            if(nums[mid] > nums[mid+1]){
                right = mid;
            }
            else{
                left = mid+1;
            }
        }
        
        return left;
    }
}
