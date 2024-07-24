/*
https://leetcode.com/problems/build-a-matrix-with-conditions/submissions/1328933651/

Time: O(max(k *k, n))
Space: O(max(k *k, n))
*/
public class Solution {
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        int[] orderRows = TopoSort(rowConditions, k);
        int[] orderColumns = TopoSort(colConditions, k);
        if (orderRows.Length == 0 || orderColumns.Length == 0)
            return new int[0][];
        
        int[][] matrix = new int[k][];
        for (int i = 0; i < k; i++) {
            matrix[i] = new int[k];
        }
        
        for (int i = 0; i < k; i++) {
            for (int j = 0; j < k; j++) {
                if (orderRows[i] == orderColumns[j]) {
                    matrix[i][j] = orderRows[i];
                }
            }
        }
        return matrix;
    }

    private int[] TopoSort(int[][] edges, int n) {
        List<int>[] adj = new List<int>[n + 1];
        for (int i = 0; i <= n; i++) {
            adj[i] = new List<int>();
        }
        
        int[] deg = new int[n + 1];
        int[] order = new int[n];
        int idx = 0;
        
        foreach (var x in edges) {
            adj[x[0]].Add(x[1]);
            deg[x[1]]++;
        }
        
        Queue<int> q = new Queue<int>();
        for (int i = 1; i <= n; i++) {
            if (deg[i] == 0) q.Enqueue(i);
        }
        
        while (q.Count > 0) {
            int f = q.Dequeue();
            order[idx++] = f;
            n--;
            foreach (var v in adj[f]) {
                if (--deg[v] == 0) q.Enqueue(v);
            }
        }
        
        if (n != 0) return new int[0];
        return order;
    }
}