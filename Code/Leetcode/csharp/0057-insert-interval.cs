/*
https://leetcode.com/problems/insert-interval/submissions/1249430786/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> result = new List<int[]>();

        int start = newInterval[0];
        int end = newInterval[1];
        int startIndex = FindFirstOverlap(intervals, start);

        if (startIndex == intervals.Length) {
            result.AddRange(intervals);
            result.Add(newInterval);
            return result.ToArray();
        }

        for (int i = 0; i < startIndex; i++) {
            result.Add(intervals[i]);
        }

        int endIndex = FindLastOverlap(intervals, end, startIndex);

        if (endIndex >= startIndex) {
            start = Math.Min(start, intervals[startIndex][0]);
            end = Math.Max(end, intervals[endIndex][1]);
        }

        result.Add(new int[] { start, end });

        for (int i = endIndex + 1; i < intervals.Length; i++) {
            result.Add(intervals[i]);
        }

        return result.ToArray();
    }

    private int FindFirstOverlap(int[][] intervals, int targetStart) {
        int low = 0, high = intervals.Length - 1;
        while (low <= high) {
            int mid = (low + high) / 2;
            if (intervals[mid][1] < targetStart) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return low;
    }

    private int FindLastOverlap(int[][] intervals, int targetEnd, int startIdx) {
        int low = startIdx, high = intervals.Length - 1;
        while (low <= high) {
            int mid = (low + high) / 2;
            if (intervals[mid][0] > targetEnd) {
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }
        return high;
    }
}
