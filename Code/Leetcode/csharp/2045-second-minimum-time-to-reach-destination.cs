/*
https://leetcode.com/problems/second-minimum-time-to-reach-destination/submissions/1336698126/

Time: O(N + E)
Space: O(N + E)
*/

public class Solution {
    public int SecondMinimum(int n, int[][] edges, int time, int change) {
        var adj = new Dictionary<int, List<int>>();
        foreach (var edge in edges) {
            int a = edge[0], b = edge[1];
            if (!adj.ContainsKey(a)) adj[a] = new List<int>();
            if (!adj.ContainsKey(b)) adj[b] = new List<int>();
            adj[a].Add(b);
            adj[b].Add(a);
        }

        int[] dist1 = new int[n + 1], dist2 = new int[n + 1];
        for (int i = 1; i <= n; i++) {
            dist1[i] = dist2[i] = -1;
        }

        var queue = new Queue<int[]>();
        queue.Enqueue(new int[] { 1, 1 });
        dist1[1] = 0;

        while (queue.Count > 0) {
            var temp = queue.Dequeue();
            int node = temp[0];
            int freq = temp[1];

            int timeTaken = freq == 1 ? dist1[node] : dist2[node];
            if ((timeTaken / change) % 2 == 1) {
                timeTaken = change * (timeTaken / change + 1) + time;
            } else {
                timeTaken += time;
            }

            if (!adj.ContainsKey(node)) continue;
            foreach (var neighbor in adj[node]) {
                if (dist1[neighbor] == -1) {
                    dist1[neighbor] = timeTaken;
                    queue.Enqueue(new int[] { neighbor, 1 });
                } else if (dist2[neighbor] == -1 && dist1[neighbor] != timeTaken) {
                    if (neighbor == n) return timeTaken;
                    dist2[neighbor] = timeTaken;
                    queue.Enqueue(new int[] { neighbor, 2 });
                }
            }
        }
        return 0;
    }
}
