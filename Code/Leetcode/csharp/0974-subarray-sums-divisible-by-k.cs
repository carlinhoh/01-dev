/*
https://leetcode.com/problems/subarray-sums-divisible-by-k/submissions/1282997593/?envType=daily-question&envId=2024-06-09

Time: O(n + k)
Space: O(k)

*/
public class Solution {
    public int SubarraysDivByK(int[] nums, int k) {
        int prefixSum = 0;
        int[] prefixes = new int[k];
        int count = 0;
        prefixes[0] = 1;
        for(int i=0;i<nums.Length;i++){
            prefixSum += nums[i];

            int remainder = prefixSum % k;
            if(remainder < 0){
                remainder += k;
            }
            count += prefixes[remainder];

            prefixes[remainder]++;
        }

        return count;
    }
}