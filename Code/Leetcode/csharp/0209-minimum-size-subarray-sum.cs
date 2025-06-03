/*
https://leetcode.com/problems/minimum-size-subarray-sum/submissions/1490683017/
*/

public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int windowSum = 0;
        int minLength = int.MaxValue;
        int windowsStart = 0;
        for(int windowEnd = 0; windowEnd < nums.Length; windowEnd++){
            windowSum += nums[windowEnd];
            while(windowSum>=target){
                minLength = Math.Min(minLength, windowEnd - windowsStart + 1);
                windowSum -= nums[windowsStart];
                windowsStart++;
            }
        }
        return minLength == int.MaxValue ? 0 : minLength;
    }
}