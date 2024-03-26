/*
https://leetcode.com/problems/climbing-stairs/submissions/1214747442/

Time: O(n)
Space: O(1)
*/
public class Solution {
  public int ClimbStairs(int n)
        {
        if(n<=2){
            return n;
        }
        int first = 1;
        int second = 2;
      
        for(int i=0;i<n-1;i++){
            second += first;                     
            first = second-first;
        }
      
      return first;
    }
}