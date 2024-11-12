/*
https://leetcode.com/problems/prime-subtraction-operation/submissions/1450100994
Time: O(n + mlog(log(m)))
Space: O(m)
*/

public class Solution {
    public bool PrimeSubOperation(int[] nums) {
        if(nums == null || nums.Length == 0){
            return true;
        }

        int max = nums.Max();

        var primes = GeneratePrimes(max);

        int curr = 1;
        int i = 0;
        while(i<nums.Length){
            int diff = nums[i] - curr;
            if(diff < 0){
                return false;
            }

            if(primes[diff] == true || diff == 0){
                i++;
                curr++;
            }
            else{
                curr++;
            }
        }
        return true;
    }

    public static bool[] GeneratePrimes(int limit)
    {
        bool[] isPrime = new bool[limit + 1];
        isPrime[1] = false;
        for (int i = 2; i <= limit; i++)
        {
            isPrime[i] = true;
        }

        for (int p = 2; p <= Math.Sqrt(limit + 1); p++)
        {
            if (isPrime[p])
            {
                for (int i = p * p; i <= limit; i += p)
                {
                    isPrime[i] = false;
                }
            }
        }

        return isPrime;
    }
}