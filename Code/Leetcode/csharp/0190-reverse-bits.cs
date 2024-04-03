/*
https://leetcode.com/problems/reverse-bits/submissions/1222243227/

Time: O(1)
Space: O(1)
*/
public class Solution {
    public uint reverseBits(uint n) {
        uint res = 0;
        int exp = 31;
        while(n>0){
            res += (n&1) << exp;
            exp--;
            n >>= 1;
        }
        return res;
    }
}