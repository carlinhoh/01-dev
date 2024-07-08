/*
https://leetcode.com/problems/find-the-winner-of-the-circular-game/submissions/1314468890/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public int FindTheWinner(int n, int k) {
        int res = 0;
        for(int i = 2;i<=n;i++){
            res = (res + k) % i;
        }
        return res + 1;
    }
}