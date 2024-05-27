/*
HashSet https://leetcode.com/problems/contains-duplicate-ii/submissions/1269376879/

Time: O(n)
Space: O(min(n,k))

Dictionary https://leetcode.com/problems/contains-duplicate-ii/submissions/1269372388/

Time: O(n)
Space: O(min(n,k))

*/
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        int left = 0;
        Dictionary<int, int> freq = new();
        for(int right = 0;right<nums.Length;right++){
            if(freq.Count == k + 1){
                freq.Remove(nums[left]);
                left++;
            }
            if(!freq.ContainsKey(nums[right])){
                freq[nums[right]] = 0;
            }
            else return true;
            freq[nums[right]]++;
        }
        return false;
    }
}