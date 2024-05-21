/*
backtracking https://leetcode.com/problems/subsets/submissions/1264370339/

Time: O(2^n * n)
Space: O(n)

Cascading https://leetcode.com/problems/subsets/submissions/1264371004/

Time: O(2^n * n)
Space: O(2^n * n)
*/
public class Solution {
    private List<IList<int>> output = new List<IList<int>>();
    private int n, k;

    private void backtrack(int first, List<int> curr, int[] nums) {
        if (curr.Count == k)
            output.Add(new List<int>(curr));
        for (int i = first; i < n; ++i) {
            curr.Add(nums[i]);
            backtrack(i + 1, curr, nums);
            curr.RemoveAt(curr.Count - 1);
        }
    }

    public IList<IList<int>> Subsets(int[] nums) {
        n = nums.Length;
        for (k = 0; k < n + 1; ++k) {
            backtrack(0, new List<int>(), nums);
        }
        return output;
    }
}

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        List<IList<int>> subs = new List<IList<int>>();
        List<int> currSubs = new List<int>();
        GenerateSubSets(0, subs, currSubs, nums);
        return subs;
    }
    
    private void GenerateSubSets(int index, List<IList<int>> subs, List<int> currSubs, int[] nums) {
        subs.Add(new List<int>(currSubs));
        
        for (int i = index; i < nums.Length; i++) {
            currSubs.Add(nums[i]);
            GenerateSubSets(i + 1, subs, currSubs, nums);
            currSubs.RemoveAt(currSubs.Count - 1);
        }
    }
}