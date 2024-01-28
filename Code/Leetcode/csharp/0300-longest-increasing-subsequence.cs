/*
#blind-75
#neetcode-150
https://leetcode.com/problems/3sum/submissions/1156851545/

Time:O(N*Log(N)), N times BinarySearch
Space:O(N), When the input is strictly increasing
*/
public class Solution {
    public int LengthOfLIS(int[] nums) {
        int n = nums.Length;
        List<int> orderedNums = new();
        orderedNums.Add(nums[0]);

        for(int i=1;i<n;i++){
            int currNum = nums[i];
            if(currNum > orderedNums.Last()){
                orderedNums.Add(currNum);
            }
            else{
                var idx = orderedNums.BinarySearch(currNum);
                if(idx<0){
                    idx = ~idx;
                }
                orderedNums.Remove(orderedNums[idx]);
                orderedNums.Insert(idx, currNum);
            }
        }
        return orderedNums.Count;
    }
}