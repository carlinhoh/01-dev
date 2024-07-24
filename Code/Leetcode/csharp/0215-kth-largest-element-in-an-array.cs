    /*
    https://leetcode.com/problems/kth-largest-element-in-an-array/submissions/1224170667/

    Time: O(n + m), where m is max - min
    Space: O(m)
    */

    public class Solution {
        public int FindKthLargest(int[] nums, int k) {
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach(int num in nums){
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }

            int[] buckets = new int[max - min + 1];
            
            for(int i=0; i<nums.Length; i++){
                buckets[nums[i] - min]++;
            }

            for(int i=buckets.Length-1; i>=0;i--){
                k -= buckets[i];
                if(k <= 0){
                    return i + min;
                }    
            }

            return default;
        }
    }