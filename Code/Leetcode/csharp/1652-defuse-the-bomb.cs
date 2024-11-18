/*
https://leetcode.com/problems/defuse-the-bomb/submissions/1455787096/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public int[] Decrypt(int[] code, int k) {
        int n = code.Length;
        int[] result = new int[n];
        if(k == 0){
            return result;
        }
        int start = 1, end = k, sum = 0;

        if(k<0){
            start = n + k;
            end = n-1;    
        }

        for(int i=start;i<=end;i++){ sum += code[i];}

        for(int i=0;i<n;i++){
            result[i] =  sum;
            sum -= code[start % n];
            sum += code[(end+1) % n];
            start++;
            end++;
        }
        return result;
    }
}