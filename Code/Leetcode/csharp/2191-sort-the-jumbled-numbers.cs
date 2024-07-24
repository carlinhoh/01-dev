/*
https://leetcode.com/problems/sort-the-jumbled-numbers/submissions/1332365311/


Time: O(n * logn)
Space: O(n)
*/
public class Solution
{
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
        List<(int MappedValue, int Index)> storePairs = new List<(int, int)>();

        for (int i = 0; i < nums.Length; i++)
        {
            int mappedValue = 0;
            int temp = nums[i];
            int place = 1;

            if (temp == 0)
            {
                storePairs.Add((mapping[0], i));
                continue;
            }
            
            while (temp != 0)
            {
                mappedValue = place * mapping[temp % 10] + mappedValue;
                place *= 10;
                temp /= 10;
            }
            storePairs.Add((mappedValue, i));
        }

        storePairs.Sort((a, b) => a.MappedValue - b.MappedValue);

        int[] answer = new int[nums.Length];
        for (int i = 0; i < storePairs.Count; i++)
        {
            answer[i] = nums[storePairs[i].Index];
        }

        return answer;
    }
}
