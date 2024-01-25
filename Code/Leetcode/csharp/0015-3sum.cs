/*
#blind-75
#neetcode-150
https://leetcode.com/problems/3sum/submissions/1156851545/

Time:O(N²)
Space:O(N)
*/
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        List<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        for(int i = 0; i < nums.Length && nums[i]<=0; i++){
            if(i==0 || nums[i-1] != nums[i]){
                TwoSum(nums, i, res);
            }
        }
        return res;
    }

    private void TwoSum(int[] nums, int i, List<IList<int>> res){
        HashSet<int> seen  = new();
        for(int j = i+1; j<nums.Length;j++){
            int complement =  -nums[i] - nums[j];
            if(seen.Contains(complement)){
                res.Add(new List<int>(){nums[i], nums[j], complement});
                while(j+1<nums.Length && nums[j]  == nums[j+1]){
                    j++;
                }
            }
            seen.Add(nums[j]);
        }
    }
}
