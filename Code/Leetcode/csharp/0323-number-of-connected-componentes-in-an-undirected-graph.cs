/*
DFS https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/submissions/1282136015/

Time: O(V + E)
Space: O(V + E)

DSU https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/submissions/1282135150/

Time: O(V + E * α(n))
Space: O(V)
*/

public class Solution {
    public int CountComponents(int n, int[][] edges) {
        List<int>[] adjList = new List<int>[n];
        
        for(int i=0;i<n;i++){
            adjList[i] = new List<int>();
        }
        
        for(int i=0;i<edges.Length;i++){                
            adjList[edges[i][0]].Add(edges[i][1]);
            adjList[edges[i][1]].Add(edges[i][0]);
        }
        int[] seen = new int[n];
        int count=0;        
        for(int i=0;i<seen.Length;i++){
            if(seen[i]==0){
                count++;
                Dfs(adjList, seen, i);
            }
        }
        return count;
    }
    public void Dfs(List<int>[] graph, int[] seen, int node){
        foreach(var neighbour in graph[node]){
            if(seen[neighbour]==0){
               seen[neighbour]=1;
                Dfs(graph, seen, neighbour);
            }
        }
    }
}
public class Solution {
    public int CountComponents(int n, int[][] edges) {
        DSU dsu = new DSU(n);
        
        for(int i=0;i<edges.Length;i++){
            dsu.Union(edges[i][0],edges[i][1]);
        }
        
        return dsu.count;
    }
    
    
    public class DSU{
        int[] rank;
        int[] root;
        public int count;
        
        
        public DSU(int n){
            rank = new int[n];
            root = new int[n];
            count = n;
            for(int i=0;i<n;i++){
                rank[i] = 1;
                root[i] = i;
            }
        }
        
        public int Find(int x){
            if(root[x]==x){
                return x;
            }
           return root[x] = Find(root[x]);
        }
        
        public void Union(int x, int y){
            var rootX = Find(x);
            var rootY = Find(y);
            
            if(rootX!=rootY){
                if(rank[rootX]>rank[rootY]){
                    root[rootY] = rootX;
                }
                else if(rank[rootX]<rank[rootY]){
                    root[rootX] = rootY;
                }
                else{
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }    
                count--;
            }
            
        }
    }
}