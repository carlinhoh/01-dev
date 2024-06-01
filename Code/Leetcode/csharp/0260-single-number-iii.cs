/*
Bitmask https://leetcode.com/problems/single-number-iii/submissions/1273799041/

Time: O(n)
Space: O(n)

HashSet https://leetcode.com/problems/single-number-iii/submissions/1273791428/

Time: O(n)
Space: O(n)

Dictionary https://leetcode.com/problems/single-number-iii/submissions/1273796889/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public int[] SingleNumber(int[] nums) {
        int bitmask = 0;

        for(int i=0;i<nums.Length;i++){
            bitmask ^= nums[i];
        }

        int diff = bitmask & (-bitmask);
        int x = 0;
        foreach(var num in nums){
            if((num & diff) != 0) x ^= num;
        }
        
        return new int[2]{x, x^bitmask};
    }
}
public class Solution {
    public int[] SingleNumber(int[] nums) {
        HashSet<int> seen = new();
        for(int i=0;i<nums.Length;i++){
            if(seen.Contains(nums[i])){
                seen.Remove(nums[i]);
            }
            else{
                seen.Add(nums[i]);
            }
        }

        int[] ans = new int[2];
        int index = 0;
        foreach(int number in seen){
            ans[index++] = number;
        }

        return ans;

    }
}
public class Solution {
    public int[] SingleNumber(int[] nums) {
        Dictionary<int, int> seen = new();
        for(int i=0;i<nums.Length;i++){
            seen.TryAdd(nums[i], 0);
            seen[nums[i]]++;
        }

        int[] ans = new int[2];
        int index = 0;
        foreach(var item in seen){
            if(item.Value == 1) ans[index++] = item.Key;
        }
        return ans;
    }
}