/*
DFS https://leetcode.com/problems/graph-valid-tree/submissions/

Time: O(n)
Space: O(n)

DisjointSet https://leetcode.com/problems/graph-valid-tree/submissions/1270877957/

Time: O(n)
Space: O(n)
*/

public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if(edges.Length != n-1){
            return false;
        }
        List<List<int>> adjacencyList = new();
        for(int i=0;i<n;i++){
            adjacencyList.Add(new List<int>());
        }
        foreach(int[] edge in edges){
            adjacencyList[edge[0]].Add(edge[1]);
            adjacencyList[edge[1]].Add(edge[0]);
        }

        Stack<int> stack = new();
        HashSet<int> seen = new();
        stack.Push(0);
        seen.Add(0);

        while(stack.Any()){
            int node = stack.Pop();
            foreach(int neighbour in adjacencyList[node]){
                if(seen.Contains(neighbour)){
                    continue;
                }
                stack.Push(neighbour);
                seen.Add(neighbour);
            }
        }

        return seen.Count == n;
    }
}

public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if(edges.Length != n-1){
            return false;
        }

        DisjointSet dsu = new(n);

        foreach(int[] edge in edges){
            var nodeX = edge[0];
            var nodeY = edge[1];

            if(!dsu.Union(nodeX, nodeY)){
                return false;
            }
        }
        return true;
    }

    public class DisjointSet{
        int[] rank;
        int[] root;

        public DisjointSet(int size){
            rank = new int[size];
            root = new int[size];

            for(int i=0;i<size;i++){
                rank[i] = 1;
                root[i] = i;
            }
        }

        public int Find(int x){
            if(root[x] == x){
                return x;
            }
            return root[x] = Find(root[x]);
        }

        public bool Union(int x, int y){
            int rootX = Find(x);
            int rootY = Find(y);
            if(rootX == rootY){
                return false;
            }
            else{
                if(rank[rootX] > rank[rootY]){
                    root[rootY] = rootX;
                }
                else if(rank[rootX] < rank[rootY]){
                    root[rootX] = rootY;
                }
                else{
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }
            }
            return true;
        }
    }
}