/*
https://leetcode.com/problems/house-robber/submissions/1235990046/

Time:O(n)
Space:O(1)
*/
public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if(n==0){
            return 0;
        }
        if(n==1){
            return nums[0];
        }

        int robHouse = nums[0];
        int robNextHouse = Math.Max(nums[0], nums[1]);
        int max = robNextHouse;

        for(int i=2;i<nums.Length;i++){
            max = Math.Max(nums[i] + robHouse, robNextHouse);
            robHouse = robNextHouse;
            robNextHouse = max;
        }
        return max;
    }
}