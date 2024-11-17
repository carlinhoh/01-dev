/*
https://leetcode.com/problems/remove-duplicates-from-sorted-array/submissions/1454747602/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int idx = 1;
        for(int p=1;p<nums.Length;p++){
            if(nums[p-1] != nums[p]){
                nums[idx++] = nums[p];
            }
        }
        return idx;
    }
}