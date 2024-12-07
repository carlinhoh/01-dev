/*
https://leetcode.com/problems/minimum-limit-of-balls-in-a-bag/submissions/1472957078

Time: O(M * log(n)), where M is nums.Max()
Space: O(1)
*/
public class Solution {
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int left = 1, right = nums.Max();
        while (left < right){
            int mid = left + (right - left) / 2, count = 0;
            foreach (int a in nums){
                count += (a - 1) / mid;
                if(count > maxOperations){
                    break;
                }
            } 
            if (count > maxOperations)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
	}
}