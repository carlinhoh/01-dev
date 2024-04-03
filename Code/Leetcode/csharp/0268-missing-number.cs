/*
https://leetcode.com/problems/missing-number/submissions/1222401083/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int MissingNumber(int[] nums) {
        //int sum = (n * (n+1))/2;
        int sum = nums.Length;
        for(int i=0;i<nums.Length;i++){
            sum += i - nums[i];
        }

        return sum;
    }
}