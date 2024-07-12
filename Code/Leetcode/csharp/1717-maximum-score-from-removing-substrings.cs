/*
https://leetcode.com/problems/maximum-score-from-removing-substrings/submissions/1319110777/

Time: O(n)
Space: O(n)
*/
public class Solution
{
    public int MaximumGain(string s, int x, int y)
    {
        if (x < y)
        {
            int temp = x;
            x = y;
            y = temp;
            s = new string(s.Reverse().ToArray());
        }

        int aCount = 0, bCount = 0, totalPoints = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char currentChar = s[i];

            if (currentChar == 'a')
            {
                aCount++;
            }
            else if (currentChar == 'b')
            {
                if (aCount > 0)
                {
                    aCount--;
                    totalPoints += x;
                }
                else
                {
                    bCount++;
                }
            }
            else
            {
                totalPoints += Math.Min(bCount, aCount) * y;
                aCount = bCount = 0;
            }
        }

        totalPoints += Math.Min(bCount, aCount) * y;

        return totalPoints;
    }
}
