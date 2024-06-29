/*
https://leetcode.com/problems/a-number-after-a-double-reversal/submissions/1304147287/

Time: O(1)
Space: O(1)
*/
public class Solution {
    public bool IsSameAfterReversals(int num) {
        if(num < 10) return true;
        else if(num % 10 == 0) return false;
        return true;
    }
}