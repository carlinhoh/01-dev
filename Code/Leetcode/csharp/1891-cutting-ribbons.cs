/*
https://leetcode.com/problems/cutting-ribbons/submissions/1252748895/?

Time: O(n log k), where k is the largest element in the array
Space: O(1)
*/

public class Solution {
    public int MaxLength(int[] ribbons, int k) {
        int left = 1;
        int right = ribbons.Max();

        while(left <= right){
            int mid = left + (right - left)/2;
            if(CanMakeRibbons(ribbons, k, mid)){
                left = mid + 1;
            }
            else{
                right = mid - 1;
            }
        }
        
        return right;
    }
    private bool CanMakeRibbons(int[] ribbons, int k, int length){
        int count = 0;
        foreach(var ribbon in ribbons){
            count += ribbon/length;
            if(count>= k) return true;
        }
        return false;
    }
}