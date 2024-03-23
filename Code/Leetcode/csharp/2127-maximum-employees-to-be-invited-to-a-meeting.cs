/*
https://leetcode.com/problems/maximum-employees-to-be-invited-to-a-meeting/submissions/1211278260/

Time: O(N)
Space: O(N)
*/

public class Solution {
 public int MaximumInvitations(int[] favorite) {
        // Number of employees
        int employeeCount = favorite.Length;
        // Tracks whether an employee has been considered in the calculation
        bool[] visited = new bool[employeeCount];
        // Counts the number of people who favor each employee - indegrees for each node
        int[] favorCount = new int[employeeCount];
        
        // Populate the favorCount array
        for (int i = 0; i < employeeCount; ++i) {
            ++favorCount[favorite[i]];
        }
        
        // Queue for processing employees in BFS manner
        Queue<int> processQueue = new Queue<int>();
        for (int i = 0; i < employeeCount; ++i) {
            if (favorCount[i] == 0) {
                visited[i] = true;
                processQueue.Enqueue(i);
            }
        }
        
        // Longest path of invitations leading exclusively to a given employee
        int[] longestPathToEmployee = new int[employeeCount];
        
        // Process employees with zero in-degree
        while (processQueue.Count > 0) {
            int currentEmployee = processQueue.Dequeue();
            int favoredByCurrent = favorite[currentEmployee];
            longestPathToEmployee[favoredByCurrent] = Math.Max(longestPathToEmployee[favoredByCurrent], longestPathToEmployee[currentEmployee] + 1);
            if (--favorCount[favoredByCurrent] == 0) {
                visited[favoredByCurrent] = true;
                processQueue.Enqueue(favoredByCurrent);
            }
        }
        
        // Variables for the maximum number of invitations
        int maxInvitationsFromCycles = 0;
        int maxInvitationsFromTwoMemberCycles = 0;
        
        // Identify and calculate contributions from loops
        for (int i = 0; i < employeeCount; ++i) {
            if (!visited[i]) {
                int cycleLength = 0;
                // Determine the length of the loop
                for (int j = i; !visited[j]; j = favorite[j]) {
                    visited[j] = true;
                    ++cycleLength;
                }
                // Special handling for two-member cycles
                if (cycleLength == 2) {
                    maxInvitationsFromTwoMemberCycles += 2 + longestPathToEmployee[i] + longestPathToEmployee[favorite[i]];
                } else {
                    // For larger cycles, just take the maximum length
                    maxInvitationsFromCycles = Math.Max(maxInvitationsFromCycles, cycleLength);
                }
            }
        }
        
        // Return the maximum of either type of cycle
        return Math.Max(maxInvitationsFromCycles, maxInvitationsFromTwoMemberCycles);
    }
}