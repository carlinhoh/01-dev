/*
Find TC: O(α(n))
Union TC: O(α(n))
IsConnected TC: O(α(n))

Space: O(n)

Note: N is the number of vertices in the graph. 𝛼 refers to the Inverse Ackermann function. In practice, we assume it's a constant. In other words, O(α(N)) is regarded as O(1) on average.
*/

public class DisjointSet {
    int[] rank;
    int[] root;

    public DisjointSet(int n) {
        rank = new int[n];
        root = new int[n];
        for (int i = 0; i < n; i++) {
            rank[i] = 1;
            root[i] = i;
        }
    }

    public int Find(int x) {
        if (root[x] == x) {
            return x;
        }
        return root[x] = Find(root[x]);
    }

    public void Union(int x, int y) {
        int rootX = Find(x);
        int rootY = Find(y);

        if (rootX != rootY) {
            if (rank[rootX] > rank[rootY]) {
                root[rootY] = rootX;
            } else if (rank[rootX] < rank[rootY]) {
                root[rootX] = rootY;
            } else {
                root[rootY] = rootX;
                rank[rootX] += 1;
            }
        }
    }

    public bool IsConnected(int x, int y) {
        return Find(x) == Find(y);
    }
}