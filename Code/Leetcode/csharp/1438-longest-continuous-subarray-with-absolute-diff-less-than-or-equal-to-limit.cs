/*
https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/submissions/1297173620/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        LinkedList<int> maxd = new LinkedList<int>();
        LinkedList<int> mind = new LinkedList<int>();
        int i = 0, j;
        for (j = 0; j <nums.Length; ++j) {
            while (maxd.Count > 0 && nums[j] > maxd.Last.Value) maxd.RemoveLast();
            while (mind.Count > 0 && nums[j] < mind.Last.Value) mind.RemoveLast();
            
            
            maxd.AddLast(nums[j]);
            mind.AddLast(nums[j]);
            
            
            if (maxd.First.Value - mind.First.Value > limit) {
                if (maxd.First.Value == nums[i]) maxd.RemoveFirst();
                if (mind.First.Value == nums[i]) mind.RemoveFirst();
                ++i; 
            }
        }
        return j - i; 
    }
}