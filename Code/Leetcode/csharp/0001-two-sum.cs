/**
#blind-75
#neetcode-150
https://leetcode.com/problems/two-sum/submissions/1151046056/
**/

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> comp = new();

        for(int i=0;i<nums.Length;i++){
            if(comp.ContainsKey(target-nums[i])){
                return new int[]{i, comp[target-nums[i]]};
            }
            comp.TryAdd(nums[i], i);
        }
        return default;
    }
}