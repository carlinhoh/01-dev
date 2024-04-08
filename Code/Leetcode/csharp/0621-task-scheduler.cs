/*
https://leetcode.com/problems/task-scheduler/submissions/1226783334/

Time: O(N)
Space: O(1)
*/

public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] freq = new int[26];
        int maxFreq = 0;
        for(int i=0;i<tasks.Length;i++){
            freq[tasks[i] - 'A']++;
            maxFreq = Math.Max(maxFreq, freq[tasks[i]-'A']);
        }

        int totalTime = (maxFreq-1) * (n+1);

        for(int i=0;i<freq.Length;i++){
            if(freq[i] ==  maxFreq){
                totalTime++;
            }
        }

        return Math.Max(tasks.Length, totalTime);
    }
}

