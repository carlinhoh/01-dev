/*
https://leetcode.com/problems/sort-the-people/submissions/1330052042/

Time: O(n * logn)
Space: O(n)
*/
public class Solution
{
    public string[] SortPeople(string[] names, int[] heights)
    {
        MergeSort(names, heights, 0, heights.Length - 1);
        return names;
    }

    private void MergeSort(string[] names, int[] heights, int start, int end)
    {
        if (start < end)
        {
            int mid = start + (end - start) / 2;
            MergeSort(names, heights, start, mid);
            MergeSort(names, heights, mid + 1, end);
            Merge(names, heights, start, mid, end);
        }
    }

    private void Merge(string[] names, int[] heights, int start, int mid, int end)
    {
        int leftSize = mid - start + 1;
        int rightSize = end - mid;

        int[] leftHeights = new int[leftSize];
        int[] rightHeights = new int[rightSize];
        string[] leftNames = new string[leftSize];
        string[] rightNames = new string[rightSize];

        for (int i = 0; i < leftSize; i++)
        {
            leftHeights[i] = heights[start + i];
            leftNames[i] = names[start + i];
        }
        for (int j = 0; j < rightSize; j++)
        {
            rightHeights[j] = heights[mid + 1 + j];
            rightNames[j] = names[mid + 1 + j];
        }

        int leftIndex = 0, rightIndex = 0;
        int mergeIndex = start;
        while (leftIndex < leftSize && rightIndex < rightSize)
        {
            if (leftHeights[leftIndex] >= rightHeights[rightIndex])
            {
                heights[mergeIndex] = leftHeights[leftIndex];
                names[mergeIndex] = leftNames[leftIndex];
                leftIndex++;
            }
            else
            {
                heights[mergeIndex] = rightHeights[rightIndex];
                names[mergeIndex] = rightNames[rightIndex];
                rightIndex++;
            }
            mergeIndex++;
        }

        while (leftIndex < leftSize)
        {
            heights[mergeIndex] = leftHeights[leftIndex];
            names[mergeIndex] = leftNames[leftIndex];
            leftIndex++;
            mergeIndex++;
        }

        while (rightIndex < rightSize)
        {
            heights[mergeIndex] = rightHeights[rightIndex];
            names[mergeIndex] = rightNames[rightIndex];
            rightIndex++;
            mergeIndex++;
        }
    }
}
