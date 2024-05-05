/*
https://leetcode.com/problems/meeting-rooms-ii/submissions/1249475349/

Time: O(nlogn)
Space: O(n)

*/
public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));
        
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        minHeap.Enqueue(intervals[0][1], intervals[0][1]);

        for(int i=1;i<intervals.Length;i++){
            if (minHeap.Peek() <= intervals[i][0]) {
                minHeap.Dequeue();
            }
            minHeap.Enqueue(intervals[i][1], intervals[i][1]);
        }

        return minHeap.Count;
    }
}