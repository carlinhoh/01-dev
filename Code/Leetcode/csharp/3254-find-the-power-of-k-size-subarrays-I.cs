/*
https://leetcode.com/problems/find-the-power-of-k-size-subarrays-i/submissions/1454769370/

Time: O(n)
Space: O(n-k)
*/
public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        int i = 0;
        int n = nums.Length;

        if( k==1){
            return nums;
        }

        int[] results = new int[n - k + 1];
        Array.Fill(results, -1);
        int consecutiveCount = 1;
        for(int j=1;j<n && i < results.Length;j++){
            if(nums[j-1] == nums[j] - 1){
                consecutiveCount++;
            }
            else{
                consecutiveCount = 1;
            }

            if(consecutiveCount >= k){
                results[j - k + 1] = nums[j];
            }
            
        }

        return results;
    }
}