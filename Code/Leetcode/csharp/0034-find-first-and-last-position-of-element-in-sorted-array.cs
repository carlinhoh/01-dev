/*
https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/submissions/1275808758/

Time: O(logn)
Space: O(1)
*/
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] res = new int[2]{-1,-1};
        int firstIndex = FindOccurrences(nums, target, true);
        if(firstIndex == -1){
            return res;
        }
        int lastIndex = FindOccurrences(nums, target, false);
        res[0] = firstIndex;
        res[1] = lastIndex;
        return res;
    }
    public int FindOccurrences(int[] nums, int target, bool FirstOcurrence) {
        int left = 0;
        int right = nums.Length-1;

        int index = -1;

        while(left <= right){
            int mid = left + (right-left) /2;
            if(nums[mid] == target){
                index = mid;
                if(FirstOcurrence){
                    right = mid - 1;// Keep looking to the left
                }
                else{
                    left = mid + 1;// Keep looking to the right
                }
            }
            else if(nums[mid] < target){
                left = mid+1;
            }
            else{
                right = mid-1;
            }
        }

        return index;
    }
}