/*
https://leetcode.com/problems/happy-number/submissions/1307575739/

Time: O(log(n))
Space: O(1)
*/
public class Solution {
    public int GetNext(int n) {
        int totalSum = 0;
        while (n > 0) {
            int d = n % 10;
            n = n / 10;
            totalSum += d * d;
        }
        return totalSum;
    }

    public bool IsHappy(int n) {
        int slowRunner = n;
        int fastRunner = GetNext(n);
        while (fastRunner != 1 && slowRunner != fastRunner) {
            slowRunner = GetNext(slowRunner);
            fastRunner = GetNext(GetNext(fastRunner));
        }
        return fastRunner == 1;
    }
}
