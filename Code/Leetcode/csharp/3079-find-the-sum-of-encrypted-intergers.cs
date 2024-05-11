/*
https://leetcode.com/problems/find-the-sum-of-encrypted-integers/submissions/1246084378/

Time: O(n * d), where d is the number of digits inside nums
Space: O(1)
*/
public class Solution {
    public int SumOfEncryptedInt(int[] nums) {
        int sum = 0;
        
        foreach(var num in nums){
            if(num < 10){
                sum += num;
            }
            else{
                int maxDigit = FindMaxDigit(num);
                int encryptedNum = GetEncryptedNumber(num, maxDigit);
                sum += encryptedNum;
            }
        }

        return sum;
    }
    
    private int FindMaxDigit(int num) {
        int maxDigit = 0;
        while (num > 0) {
            int digit = num % 10;
            if (digit > maxDigit) {
                maxDigit = digit;
            }
            num /= 10;
        }
        return maxDigit;
    }
    private int GetEncryptedNumber(int num, int maxDigit) {
        int encryptedNum = 0;
        int mult = 1;
        while (num > 0) {
            encryptedNum += maxDigit * mult;
            mult *= 10;
            num /= 10;
        }
        return encryptedNum;
    }
}

public class Solution {
    public int SumOfEncryptedInt(int[] nums) {
        var sum=0;
        for (var i=0;i<nums.Length;++i) {
            var num=nums[i];
            var max=0;
            var digits=0;
            while(num>0) {
                max=Math.Max(max, num%10);
                num/=10;
                digits=digits*10+1;
            }
            sum+= digits*max;
        }
        return sum;
    }
}