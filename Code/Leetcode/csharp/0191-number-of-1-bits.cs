/*
https://leetcode.com/problems/number-of-1-bits/submissions/1222158376/

Time: O(1)
Space: O(1)
*/
public class Solution {
    public int HammingWeight(int n) {
       int count = 0;
       while(n > 0 ){
        count += n & 1;
        n >>= 1;
       }

       return count;
    }
}