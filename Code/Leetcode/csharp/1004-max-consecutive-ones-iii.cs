/*
https://leetcode.com/problems/max-consecutive-ones-iii/submissions/1257506775/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public int LongestOnes(int[] nums, int k) {
        int zeros = 0;
        int left = 0;
        int right = 0;
        
        while (right < nums.Length) {
            if (nums[right] == 0) {
                zeros++;
            }
            right++;
            
            if (zeros > k) {
                if (nums[left] == 0) {
                    zeros--;
                }
                left++;
            }
        }
        
        return right - left;
    }
}

public class Solution {
    public int LongestOnes(int[] nums, int k) {
       int left = 0;
        int max = 0;
        int zeros = 0;
        
        for (int right = 0; right < nums.Length; right++) {
            if (nums[right] == 0) {
                zeros++;
            }
            
            while (zeros > k) {
                if (nums[left] == 0) {
                    zeros--;
                }
                left++;
            }
            
            max = Math.Max(max, right - left + 1);
        }
        
        return max;
    }
}