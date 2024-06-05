/*
https://leetcode.com/problems/task-scheduler-ii/submissions/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public long TaskSchedulerII(int[] tasks, int space) {
        Dictionary<int, long> lastTask=new();
        long days=0;
        for(int i=0;i<tasks.Length;i++)
        {
            if(lastTask.ContainsKey(tasks[i]))
            {
                days = Math.Max(days, lastTask[tasks[i]] + space + 1);
            }

            lastTask[tasks[i]] = days;
            days++;
        }

        return days;
    }
}