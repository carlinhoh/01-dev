/*
https://leetcode.com/problems/maximum-swap/submissions/1256995364/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public int MaximumSwap(int num) {
        char[] A = num.ToString().ToCharArray();

        int[] last = new int[10];
        for(int i=0;i<A.Length;i++){
            last[A[i] - '0'] = i;
        }
        for (int i = 0; i < A.Length; i++) {
            for (int d = 9; d > A[i] - '0'; d--) {
                if (last[d] > i) {
                    char tmp = A[i];
                    A[i] = A[last[d]];
                    A[last[d]] = tmp;
                    return int.Parse(new string(A));
                }
            }
        }
        return num;
    }
}