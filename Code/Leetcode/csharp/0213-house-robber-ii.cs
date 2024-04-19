/*
https://leetcode.com/problems/house-robber-ii/submissions/1236669567/

Time:O(n)
Space: O(1)
*/

public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;

        if (n == 1) {
            return nums[0];
        }
        if (n == 2) {
            return Math.Max(nums[0], nums[1]);
        }
        return Math.Max(HouseRobber(nums, 1, n-1), HouseRobber(nums, 0, n-2));
    }

    public int HouseRobber(int[] nums, int start, int end){
        int robHouse = nums[start];
        int robNextHouse = Math.Max(nums[start], nums[start + 1]);
        int max = robNextHouse;

        for (int i = start + 2; i <= end; i++) {
            max = Math.Max(nums[i] + robHouse, robNextHouse);
            robHouse = robNextHouse;
            robNextHouse = max;
        }
        return max;
    }
}
