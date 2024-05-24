/*

https://leetcode.com/problems/move-zeroes/submissions/1266852448/

Time: O(n)
Space: O(1)

Two Pointers https://leetcode.com/problems/move-zeroes/submissions/1266851769/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public void MoveZeroes(int[] nums) {
        int n = 0;
        
        for(int i=0;i<nums.Length;i++){
            if(nums[i]!=0){
                nums[n++] = nums[i];
            }
        }
        for(int j=n;j<nums.Length;j++){
            nums[j] = 0;
        }
    }
}
public class Solution {
    public void MoveZeroes(int[] nums) {
        int p1 = -1;
        if(nums.Length == 1){
            return;
        }
        for(int p2 = 0;p2<nums.Length;p2++){
            if(p1 < 0  && nums[p2] == 0){
                p1 = p2;
            }
            if(nums[p2] != 0 && p1 >= 0){
                nums[p1++] = nums[p2];
                nums[p2] = 0;
            }
        }
    }
}