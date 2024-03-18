/*
#blind-75
#neetcode-150
https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/submissions/1207309866/

Time: O(logN)
Space: O(1)
*/
public class Solution { 
 public int FindMin(int[] nums) {
        if(nums == null){
            return -1;
        }
        if(nums.Length == 2){
            return Math.Min(nums[0], nums[1]);
        }
        int left = 0;
        int right = nums.Length-1;
        while(left<right){
            int mid = left + (right-left)/2;

            if(nums[mid]>nums[right]){
                left = mid+1;
            }
            else{
                right = mid;
            }
        }
        return nums[right];
    }
}
/*
if nums[mid]>nums[right] is true, the array has been rotated at least once and the smallest element is on the right. Note that if the array is rotated once or n-1 times and the value on the right is less than mid - the smallest value is on the right or is mid itself. 

If this doesn't happen (there is no value smaller than mid on the right), it means that the smallest value is on the left or is mid itself.

At the end of the solution, the indexes will converge to the same value. 

Here a iteration with some possibilities:

[3,4,5,1,2] -> Rotated, smallest in the right

Iteration #1
nums[mid]: 5  -  mid: 2
nums[left] 3  -  left: 0
nums[right]: 2  -  right: 4
Check: 
nums[mid]>nums[right], so left = mid+1 
left: 3
right: 4
End iteration #1 ...

Iteration 2#
nums[mid]: 1  -  mid: 3
nums[left] 1  -  left: 3
nums[right]: 2  -  right: 4
Check: 
nums[mid]<=nums[right], so right = mid 
left: 3
right: 3
End iteration 2...

left == right, so return nums[right]
-----------------------------------------------------------

[5,1,2,3,4] -> rotated, smallest in the left

Iteration #1
nums[mid]: 2  -  mid: 2
nums[left] 5  -  left: 0
nums[right]: 4  -  right: 4
Check: 
nums[mid]<=nums[right], so right = mid 
left: 0
right: 2
End iteration #1...

Iteration #2
nums[mid]: 1  -  mid: 1
nums[left] 5  -  left: 0
nums[right]: 2  -  right: 2
Check: 
nums[mid]<=nums[right], so right = mid 
left: 0
right: 1
End iteration #2...

Iteration #3
nums[mid]: 5  -  mid: 0
nums[left] 5  -  left: 0
nums[right]: 1  -  right: 1
Check: 
nums[mid]>nums[right], so left = mid+1 
left: 1
right: 1
End iteration #3...

left == right, so return nums[right]

-----------------------------------------------------------
[1,2,3,4,5,6,7,8,9] - rotated n times or none

Iteration #1
nums[mid]: 5  -  mid: 4
nums[left] 1  -  left: 0
nums[right]: 9  -  right: 8
Check: 
nums[mid]<=nums[right], so right = mid 
left: 0
right: 4
End iteration #1...


Iteration #2
nums[mid]: 3  -  mid: 2
nums[left] 1  -  left: 0
nums[right]: 5  -  right: 4
Check: 
nums[mid]<=nums[right], so right = mid 
left: 0
right: 2
End iteration #2...


Iteration #3
nums[mid]: 2  -  mid: 1
nums[left] 1  -  left: 0
nums[right]: 3  -  right: 2
Check: 
nums[mid]<=nums[right], so right = mid 
left: 0
right: 1
End iteration #3...


Iteration #4
nums[mid]: 1  -  mid: 0
nums[left] 1  -  left: 0
nums[right]: 2  -  right: 1
Check: 
nums[mid]<=nums[right], so right = mid 
left: 0
right: 0
End iteration #4...

left == right, so return nums[right]

*/