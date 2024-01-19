/**
#blind-75
#neetcode-150
https://leetcode.com/problems/contains-duplicate/submissions/1150270752/
**/
public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        
        HashSet<int> set = new HashSet<int>(nums.Length);
        
        foreach(var num in nums){
            if(!set.Add(num)){
                return true;
            }
        }
        return false;
    }
}