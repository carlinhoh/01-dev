/*
https://leetcode.com/problems/maximum-number-of-integers-to-choose-from-a-range-i/submissions/1471478668/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) {
        HashSet<int> ban = new(banned);
        int count = 0;
        int currentSum = 0;
        for(int i=1;i<=n;i++){
            if(!ban.Contains(i) && currentSum + i <= maxSum){
                count++;
                currentSum += i;
            }
        }

        return count;
    }
}