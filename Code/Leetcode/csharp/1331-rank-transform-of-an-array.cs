/*
https://leetcode.com/problems/rank-transform-of-an-array/submissions/1263420692/

Time: O(nlogn)
Space: O(n)
*/

public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        int[] resArr = new int[arr.Length];
        int rank = 1;

        int[] temp = new int[arr.Length];
        Array.Copy(arr, temp, arr.Length);
        Array.Sort(temp);

        Dictionary<int, int> rMap = new Dictionary<int, int>();

        foreach (int num in temp)
        {
            if (!rMap.ContainsKey(num))
            {
                rMap[num] = rank++;
            }
        }

        for (int i = 0; i < arr.Length; i++)
        {
            resArr[i] = rMap[arr[i]];
        }

        return resArr;
    }
}