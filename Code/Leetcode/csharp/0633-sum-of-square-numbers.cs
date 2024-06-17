/*
https://leetcode.com/problems/sum-of-square-numbers/submissions/1290615698/

Time: O(sqrt(c))
Space: O(1)

https://leetcode.com/problems/sum-of-square-numbers/submissions/1290614719/

Time: O(sqrt(c) log(c))
Space: O(1)
*/
public class Solution {
public bool JudgeSquareSum(int c) {
        long a= 0;
        long b= (int)Math.Sqrt(c);

        while(a<=b){
            long sum = a*a + b*b;
            if(sum == c){
                return true;
            }
            else if(sum<c){
                a++;
            }
            else{
                b--;
            }
        }
        return false;
    }
}
public class Solution {
    public bool JudgeSquareSum(int c) {
        for (long a = 0; a * a <= c; a++) {
            double b = Math.Sqrt(c - a * a);
            if (b == (int) b)
                return true;
        }
        return false;
    }
}