/*
https://leetcode.com/problems/counting-bits/submissions/1222205702/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public int[] CountBits(int n) {
        int[] res = new int[n+1];
        for(int i=1;i<n+1;i++){
            res[i] = res[i & (i-1)] + 1;
        }
        return res;
    }
}