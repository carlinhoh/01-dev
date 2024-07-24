/*
https://leetcode.com/problems/sort-array-by-increasing-frequency/submissions/1331302598/

Time: O(n * logn)
Space: O(n)

*/
public class Solution
{
    public int[] FrequencySort(int[] nums)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (freq.ContainsKey(num))
            {
                freq[num]++;
            }
            else
            {
                freq[num] = 1;
            }
        }

        return nums
            .OrderBy(num => freq[num])
            .ThenByDescending(num => num)
            .ToArray();
    }
}
