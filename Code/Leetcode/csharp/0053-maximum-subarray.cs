/*
https://leetcode.com/problems/maximum-subarray/submissions/1224187256/

Time: O(N)
Space: O(1)
*/
public class Solution {
    public int MaxSubArray(int[] nums) {
        int n = nums.Length;
        if(n==0){
            return 0;
        }
        int currentSum = nums[0];
        int globalSum = nums[0];
        for(int i=1;i<n;i++){
            currentSum = Math.Max(currentSum + nums[i], nums[i]);
            globalSum = Math.Max(globalSum, currentSum);
        }
        
        return globalSum;
    }
}