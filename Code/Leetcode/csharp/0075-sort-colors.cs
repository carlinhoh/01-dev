/*
One pass https://leetcode.com/problems/sort-colors/submissions/1285545141/

Time: O(n)
Space: O(1)

Count sort https://leetcode.com/problems/sort-colors/submissions/1285536866/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public void SortColors(int[] nums) {
        int left = 0;
        int right = nums.Length - 1;
        int pointer = 0;

        while(pointer <= right){
            if(nums[pointer] == 0) Swap(nums, pointer++, left++);
            else if(nums[pointer] == 2) Swap(nums, pointer, right--);
            else pointer++;
        }

    }

    private void Swap(int[] nums, int x, int y){
        int temp = nums[x];
        nums[x] = nums[y];
        nums[y] = temp;
    }
}
public class Solution {
    public void SortColors(int[] nums) {
        int[] colors = new int[3];
        for(int i=0;i<nums.Length;i++){
            colors[nums[i]]++;
        }
        int pointerNums = 0;
        int pointerColors = 0;
        while(pointerNums < nums.Length){
            if(colors[pointerColors] > 0){
                nums[pointerNums++] = pointerColors;
                colors[pointerColors]--;
            }
            else{
                pointerColors++;
            }
        }
    }
}
