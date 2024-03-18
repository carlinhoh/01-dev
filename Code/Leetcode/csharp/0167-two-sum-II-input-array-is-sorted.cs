/*
https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/submissions/1207490335/

Time:O(N)
Space:O(1)
*/

public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0;
        int right = numbers.Length-1;
        while(numbers[left] + numbers[right] != target ){
            if(numbers[left]+numbers[right] >  target){
                right--;
            }
            else{
                left++;
            }
        }
        return new int[] {left+1, right+1};
    }
}