/*
https://leetcode.com/problems/exclusive-time-of-functions/submissions/1250354409/

Time: O(L), where L is the number of logs
Space: O(N) 
*/
public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int[] result = new int[n];
        Stack<int> callStack = new();
        int prevTime = 0;

        for(int i=0;i<logs.Count;i++){
            string[] logInfo = logs[i].Split(":");
            int id = int.Parse(logInfo[0]);
            var action = logInfo[1];
            int time = int.Parse(logInfo[2]);

            if(action == "start"){
                if(callStack.Count > 0){
                    result[callStack.Peek()] += time-prevTime;
                }
                callStack.Push(id);
                prevTime = time;
            }
            else{
                int currentId = callStack.Pop(); 
                result[currentId] += time - prevTime + 1;
                prevTime = time + 1;
            }
        }

        return result;
    }
}