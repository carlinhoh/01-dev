/*
https://leetcode.com/problems/n-th-tribonacci-number/submissions/1275871416/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int Tribonacci(int n) {
        if(n<3){
            return n > 0 ? 1 : 0;
        }
        int a = 0, b = 1, c = 1;

        for(int i=0;i<n-2;i++){
            int tmp = a + b + c;
            a = b;
            b = c;
            c = tmp;
        }

        return c;
    }
}