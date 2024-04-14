/*
https://leetcode.com/problems/maximum-product-subarray/submissions/1232544424/

Time: O(N)
Space: O(1)
*/
public class Solution {
    public int MaxProduct(int[] nums) {        
        if (nums == null || nums.Length == 0)
            return default;

        int maxProd = nums[0];
        int minProd = maxProd;
        int maxResult = maxProd;

        for (int i = 1; i < nums.Length; i++) {
            int temp = maxProd;
            maxProd = Math.Max(nums[i], Math.Max(maxProd * nums[i], minProd * nums[i]));
            minProd = Math.Min(nums[i], Math.Min(temp * nums[i], minProd * nums[i]));
            maxResult = Math.Max(maxResult, maxProd);
        }

        return maxResult;
    }
}