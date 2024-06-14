/*
https://leetcode.com/problems/minimum-increment-to-make-array-unique/submissions/1288472937/

Time: O(n + max)
Space: O(n + max)
*/
public class Solution {
    public int MinIncrementForUnique(int[] nums) {
        int n = nums.Length;
        int max = nums.Max();
        int minIncrements = 0;

        int[] frequencyCount = new int[n + max];

        foreach (int val in nums) {
            frequencyCount[val]++;
        }

        for (int i = 0; i < frequencyCount.Length; i++) {
            if (frequencyCount[i] <= 1) continue;

            int duplicates = frequencyCount[i] - 1;
            frequencyCount[i + 1] += duplicates;
            minIncrements += duplicates;
        }

        return minIncrements;
    }
}