/*
https://leetcode.com/problems/pass-the-pillow/submissions/1312101563/

Time: O(1)
Space: O(1)
*/
public class Solution {
    public int PassThePillow(int n, int time) {
        int fullRounds = time / (n-1);
        int extraTime = time % (n-1);

        if(fullRounds % 2 == 0){
            return extraTime + 1;
        }
        else{
            return n - extraTime;
        }
    }
} 