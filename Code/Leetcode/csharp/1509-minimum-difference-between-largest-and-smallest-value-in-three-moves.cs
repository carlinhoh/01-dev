/*
https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves/submissions/1308768438/

Time: O(n)
Space: O(1)

*/
public class Solution
{
    public int MinDifference(int[] nums)
    {
        int numsSize = nums.Length;
        if (numsSize <= 4)
        {
            return 0;
        }

        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        foreach (int num in nums)
        {
            maxHeap.Enqueue(num, num);
            if (maxHeap.Count > 4)
            {
                maxHeap.Dequeue();
            }
        }
        List<int> smallestFour = maxHeap.UnorderedItems.Select(item => item.Element).ToList();
        smallestFour.Sort();

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > 4)
            {
                minHeap.Dequeue();
            }
        }
        List<int> largestFour = minHeap.UnorderedItems.Select(item => item.Element).ToList();
        largestFour.Sort();

        int minDiff = int.MaxValue;
        for (int i = 0; i < 4; i++)
        {
            minDiff = Math.Min(minDiff, largestFour[i] - smallestFour[i]);
        }

        return minDiff;
    }
}
