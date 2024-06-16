/*
https://leetcode.com/problems/patching-array/submissions/1290328292/

Time: O(m + log(n)), where m is the size of the pointer p
Space: O(n)
*/
public class Solution {
    public int MinPatches(int[] nums, int n) {
        int patches = 0;
        long miss = 1;
        int p = 0;
        while(miss <= n){
            if(p < nums.Length && nums[p] <= miss){
                miss += nums[p];
                p++;
            }
            else{
                miss += miss;
                patches++;
            }
        }

        return patches;
    }
}