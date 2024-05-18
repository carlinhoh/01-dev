/*
https://leetcode.com/problems/next-permutation/submissions/1261635947/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public void NextPermutation(int[] nums) {
        int n = nums.Length;
        int pivot = n - 2;

        while (pivot >= 0 && nums[pivot + 1] <= nums[pivot]) {
            pivot--;
        }

        if (pivot >= 0) {
            int i = n - 1;
            while (nums[i] <= nums[pivot]) {
                i--;
            }
            Swap(nums, pivot, i);
        }

        int left = pivot + 1;
        int right = n - 1;
        while (left < right) {
            Swap(nums, left, right);
            left++;
            right--;
        }
    }

    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
