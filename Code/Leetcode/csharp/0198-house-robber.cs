/*
https://leetcode.com/problems/house-robber/submissions/1228919942/

Time:O(n)
Space:O(1)
*/
public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        
        if(n==1){            
            return nums[0];
        }
        if(n==2){            
            return Math.Max(nums[0],nums[1]);
        }

        int robNext = nums[n-1];
        int robNextPlusOne = 0;
        
        for(int i=n-2;i>=0;i--){
            int current = Math.Max(robNext, robNextPlusOne+nums[i]);
            robNextPlusOne = robNext;
            robNext = current;
        }
        
        return robNext;
    }
}