/*
https://leetcode.com/problems/course-schedule/submissions/1276783382/

Time: O(m + n)
Space: O(m + n)
*/
public class Solution {
    HashSet<int> visited;
    HashSet<int> recStack;

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        List<List<int>> adjList = new();
        visited = new();
        recStack = new();
        for(int i = 0; i < numCourses; i++) {
            adjList.Add(new List<int>());
        }

        foreach(int[] prerequisite in prerequisites) {
            adjList[prerequisite[0]].Add(prerequisite[1]);
        }

        for(int i = 0; i < numCourses; i++) {
            if(!Dfs(adjList, i)) {
                return false;
            }
        }
        return true;
    }

    public bool Dfs(List<List<int>> adjList, int node) {
        if(recStack.Contains(node)) {
            return false;
        }

        if(visited.Contains(node)) {
            return true;
        }

        visited.Add(node);
        recStack.Add(node);

        foreach(var neighbor in adjList[node]) {
            if(!Dfs(adjList, neighbor)) {
                return false;
            }
        }

        recStack.Remove(node);
        return true;
    }
}