/*
https://leetcode.com/problems/guess-number-higher-or-lower/submissions/1206715553/

Time: O(logN)
Space: O(1)

*/
public class Solution : GuessGame {
    public int GuessNumber(int n) {
        int left = 1;
        int right = n;

        while(left <= right){
            int mid = left + (right - left)/2;

            int pick = guess(mid);
            
            if(pick == 0){
                return mid;
            }
            else if(pick == -1){
                right = mid-1;
            }
            else{
                left = mid+1;
            }
        }
        return default;
    }
}