/*
https://leetcode.com/problems/plus-one/submissions/1277794136/?

Time: O(n)
Space: O(n)
*/
public class Solution {
    public int[] PlusOne(int[] digits) {
        int n = digits.Length;

        for(int i= n-1;i >=0 ; i--){
            if(digits[i] == 9){
                digits[i] = 0;
            }
            else{
                digits[i]++;
                return digits;
            }
        }

        int[] result = new int[n+1];
        result[0] = 1;
        return result;
    }
}