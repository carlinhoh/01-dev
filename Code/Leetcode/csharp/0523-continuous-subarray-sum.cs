/*
https://leetcode.com/problems/continuous-subarray-sum/submissions/1251467156/

Time: O(n)
Space: O(k)

2 approach https://leetcode.com/problems/continuous-subarray-sum/submissions/1251883714/
Time: O(n)
Space: O(k)

*/
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        if (k == 0) return false;
        HashSet<int> seen = new();
        int prefixSum = 0;
        int prevMod = 0;

        for(int j=0;j<nums.Length;j++){
            prefixSum += nums[j];
            
            if(seen.Contains(prefixSum % k)) return true;

            seen.Add(prevMod);
            prevMod = prefixSum % k;
        }

        return false;
    }
}
public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        if (nums.Length < 2) return false;
        
        int sum = 0, prefix=0;
        HashSet<int> prefixSums = new();

        for(int i=0;i<nums.Length;i++){
            sum += nums[i];
            sum %= k;

            if(prefixSums.Contains(sum)){
                return true;
            }

            prefixSums.Add(prefix);
            prefix = sum;
        }
        
        return false;
    }
}