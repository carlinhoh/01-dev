/*
https://leetcode.com/problems/minimum-number-of-k-consecutive-bit-flips/submissions/1298227313/

Time: O(n)
Space: O(1)

*/
public class Solution {
    public int MinKBitFlips(int[] nums, int k) {
        int currentFlips = 0; 
        int totalFlips = 0; 

        for (int i = 0; i < nums.Length; i++) {
            if (i >= k && nums[i - k] == 2) {
                currentFlips--;
            }

            if ((currentFlips % 2) == nums[i]) {
                if (i + k > nums.Length) {
                    return -1;
                }
                nums[i] = 2;
                currentFlips++;
                totalFlips++;
            }
        }

        return totalFlips;
    }
}
