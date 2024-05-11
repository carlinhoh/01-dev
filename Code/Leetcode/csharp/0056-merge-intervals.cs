/*
https://leetcode.com/problems/merge-intervals/submissions/1249350931/

Time: O(nlogn)
Space: O(n), space for sorting and for return
*/
public class Solution {
    public int[][] Merge(int[][] intervals) {
        
        List<int[]> mergedIntervals = new();

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        int[] currentInterval = intervals[0];

        mergedIntervals.Add(currentInterval);

        foreach(var interval in intervals){
            if(interval[0] <= currentInterval[1]){
                currentInterval[1] = Math.Max(currentInterval[1], interval[1]);
            }
            else{
                currentInterval = interval;
                mergedIntervals.Add(interval);
            }
        }

        return mergedIntervals.ToArray();
    }
}