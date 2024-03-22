/*
https://leetcode.com/problems/number-of-islands-ii/submissions/1210517116/

Time: O(m*n + l), where l is the number of positions
Space: O(m*n)
*/

public class Solution {
    private int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

    public IList<int> NumIslands2(int m, int n, int[][] positions) {
        int size = m*n;

        UnionFind islands = new(size);

        List<int> res = new();

        HashSet<int> landPositions = new();

        foreach(var position in positions){
            int row = position[0];
            int col = position[1];
            int pos = n*row+col;

            if(landPositions.Contains(pos)){
                res.Add(islands.Connections);
                continue;
            }

            landPositions.Add(pos);

            islands.Connections++;

            foreach(var direction in directions){
                int adjRow = row + direction[0], adjCol = col + direction[1];
                int adjPos = adjRow * n + adjCol;
                if (adjRow >= 0 && adjRow < m && adjCol >= 0 && adjCol < n && landPositions.Contains(adjPos)) {
                    islands.Union(pos, adjPos);
                }
            }

            res.Add(islands.Connections);
        }

        return res;
    }


    public class UnionFind{
        private int[] root;
        private int[] rank;
        public int Connections { get; set; }

        public UnionFind(int size){
            rank = new int[size];
            root = new int[size];

            for(int i=0;i<size;i++){
                root[i] = i;
                rank[i] = 1;
            }
        }

        public int find(int x){
            if(x==root[x]){
                return x;
            }
            return root[x] = find(root[x]);
        }

        public void Union(int x, int y){
            int rootX = find(x);
            int rootY = find(y);
            if(rootX!=rootY){
                if(rank[rootX] > rank[rootY]){
                    root[rootY] = rootX;
                }
                else if(rank[rootX] < rank[rootY]){
                    root[rootX] = rootY;
                    
                }
                else{
                    root[rootY] = rootX;
                    rank[rootX]++;
                }
                Connections--;
            }
        }

        public bool Connected(int x, int y){
            return find(x) == find(y);
        }
    }
} 
