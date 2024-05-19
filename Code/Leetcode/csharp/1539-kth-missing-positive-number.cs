/*
https://leetcode.com/problems/kth-missing-positive-number/submissions/1261953395/

Time: O(logn)
Space: O(1)
*/

public class Solution {
    public int FindKthPositive(int[] arr, int k) {
        
        int left = 0;
        int right = arr.Length - 1;

        while(left <= right){
            int mid = left + (right - left)/2;
            int interval = arr[mid] - (mid + 1);

            if( interval < k){
                left = mid + 1;
            }
            else{
                right = mid - 1;
            }
        }

        return left + k;
    }
}