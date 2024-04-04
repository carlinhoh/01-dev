/*
https://leetcode.com/problems/sum-of-two-integers/submissions/1223485766/

Time: O(1)
Space: O(1)
*/
public class Solution {
    public int GetSum(int a, int b) {
        if(b>a){
            return GetSum(b,a);
        }

        while(b != 0){
            int answer = a^b;
            b = (a&b) << 1;
            a = answer;
        }

        return a;
    }
}