/*
#blind-75
#neetcode-150
https://leetcode.com/problems/longest-consecutive-sequence/submissions/1152976741/

Time: O(N)
Space: O(N)
*/
public class Solution {
   public int LongestConsecutive(int[] nums)
        {
            HashSet<int> setOfNums = new HashSet<int>(nums);

            int longestStreak = 0;

            foreach (var num in setOfNums)
            {
                if (!setOfNums.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;
                    while (setOfNums.Contains(currentNum + 1))
                    {
                        setOfNums.Remove(currentNum+1);
                        currentNum++;
                        currentStreak++;
                    }
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }
            return longestStreak;
        }
}