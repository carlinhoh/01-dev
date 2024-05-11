/*
https://leetcode.com/problems/powx-n/submissions/1250241218/

Time: O(logn)
Space: O(logn)
*/
public class Solution {
    public double MyPow(double x, int n) {
        return MyPowHelper(x, (long)n); 
    }

    public double MyPowHelper(double x, long n) {
        if(n == 0)  return 1;

        else if(n < 0) return 1 / MyPowHelper(x, -n);

        else{
            if(n%2 == 0){
                return MyPowHelper(x*x, n / 2);
            }
            else{
                return x * MyPowHelper(x*x, (n-1) / 2);
            }
        } 
    }
}