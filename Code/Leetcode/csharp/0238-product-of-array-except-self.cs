/*
#blind-75
#neetcode-150
https://leetcode.com/problems/product-of-array-except-self/submissions/1151979524/

Time: O(N)
Space: O(N), or O(1) if the array 'answer' doens't count
*/
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] ans = new int[nums.Length];
        ans[0] = 1;
        for(int i=1;i<nums.Length;i++){
            ans[i] = nums[i-1] * ans[i-1];
        }
        int cumulative = 1;
        for(int i=nums.Length-1;i>=0;i--){
            ans[i] *= cumulative;
            cumulative *= nums[i];
        }
        return ans;
    }
}
