/*
https://leetcode.com/problems/sort-an-array/submissions/1333537995/

Time: O(n + k), where k is the range value of nums elements
Space: O(n)
*/
public class Solution
{
    private void CountingSort(int[] arr)
    {
        Dictionary<int, int> counts = new Dictionary<int, int>();
        int minVal = arr[0], maxVal = arr[0];
        
        for (int i = 0; i < arr.Length; i++)
        {
            minVal = Math.Min(minVal, arr[i]);
            maxVal = Math.Max(maxVal, arr[i]);
            if (!counts.ContainsKey(arr[i]))
            {
                counts[arr[i]] = 0;
            }
            counts[arr[i]]++;
        }
        
        int index = 0;
        for (int val = minVal; val <= maxVal; ++val)
        {
            while (counts.ContainsKey(val) && counts[val] > 0)
            {
                arr[index] = val;
                index++;
                counts[val]--;
            }
        }
    }

    public int[] SortArray(int[] nums)
    {
        CountingSort(nums);
        return nums;
    }
}
