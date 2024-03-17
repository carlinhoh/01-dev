/*
https://leetcode.com/problems/sqrtx/submissions/1206714188/

Time: O(log(N))
Space: O(1)
*/
public class Solution {
    public int MySqrt(int x) {
        if(x<2){
            return x;
        }
        int left = 2;
        int right = x/2;
        long guess;

        while(left<=right){
            int mid = left + (right - left)/2;
            guess = (long) mid*mid;    
            if(guess == x){
                return mid;
            }
            else if(guess < x){
                left = mid + 1; 
            }
            else if(guess > x){
                right = mid-1;
            }
        }
        return right;
    }
}