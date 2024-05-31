/*
DFS https://leetcode.com/problems/tree-diameter/submissions/1272810052/

Time: O(n)
Space: O(n)

TWO TIMES BFS https://leetcode.com/problems/tree-diameter/submissions/1272778554/

Time: O(n)
Space: O(n)
*/

public class Solution {
    int diameter = 0;
    public int TreeDiameter(int[][] edges) {
        List<List<int>> adjacencyList = new();

        for(int node=0;node<edges.Length + 1;node++){
            adjacencyList.Add(new List<int>());
        }

        foreach(int[] edge in edges){
            adjacencyList[edge[0]].Add(edge[1]);
            adjacencyList[edge[1]].Add(edge[0]);
        }

        GetDepth(adjacencyList, -1,  0);

        return diameter;
    }

    public int GetDepth(List<List<int>> tree, int rootParent, int root){
        int maxDepth1 = 0;
        int maxDepth2 = 0;

        foreach(int neighbor in tree[root]){
            if(neighbor == rootParent){
                continue;//avoid cycles
            }
            int depth = GetDepth(tree, root, neighbor);

            if(depth > maxDepth1){
                maxDepth2 = maxDepth1;
                maxDepth1 = depth;
            }
            else if(depth > maxDepth2){
                maxDepth2 = depth;
            }
        }
        diameter = Math.Max(diameter, maxDepth1 + maxDepth2);

        return maxDepth1 + 1;
    }
}   
public class Solution {
   public int TreeDiameter(int[][] edges) {
        List<HashSet<int>> graph = new List<HashSet<int>>();
        for (int i = 0; i < edges.Length + 1; ++i) {
            graph.Add(new HashSet<int>());
        }

        foreach (int[] edge in edges) {
            int u = edge[0], v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }

        // 1). Find one of the farthest nodes
        int[] nodeDistance = Bfs(0, graph);
        // 2). Find the other farthest node and the distance between two farthest nodes
        nodeDistance = Bfs(nodeDistance[0], graph);

        return nodeDistance[1];
    }
    
    private int[] Bfs(int start, List<HashSet<int>> graph) {
        bool[] visited = new bool[graph.Count];
        visited[start] = true;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        int lastNode = start, distance = -1;

        while (queue.Count > 0) {
            int levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++) {
                int nextNode = queue.Dequeue();
                foreach (int neighbor in graph[nextNode]) {
                    if (!visited[neighbor]) {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                        lastNode = neighbor;
                    }
                }
            }
            // Increase the distance for each level of BFS traversal.
            distance += 1;
        }

        return new int[] { lastNode, distance };
    }
}