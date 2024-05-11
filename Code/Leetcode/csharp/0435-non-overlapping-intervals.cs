/*
https://leetcode.com/problems/non-overlapping-intervals/submissions/1249467332/

Time: O(nlogn)
Space: O(logn), Array.Sort() is implemented using a variant of the Quick Sort algorithm, which has a space complexity of O(logn)
*/
public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int prevEnd = intervals[0][1];
        int prevStart = intervals[0][0];
        int count = 0;

        for(int i=1;i<intervals.Length;i++){
             if (intervals[i][0] < prevEnd) {
                count++;
            } else {
                prevEnd = intervals[i][1];
            }
        }
        return count;
    }
}