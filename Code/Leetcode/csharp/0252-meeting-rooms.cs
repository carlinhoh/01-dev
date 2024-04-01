/*
https://leetcode.com/problems/meeting-rooms/submissions/1220555261/

Time: O(NlogN)
Space: O(logN)
*/
public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
        if(intervals.Length == 1){
            return true;
        }

        Array.Sort(intervals, (a,b) => a[0] - b[0]);

        for(int i=0;i<intervals.Length-1;i++){
            if(intervals[i][1] > intervals[i+1][0]){
                return false;
            }
        }

        return true;
    }
}