/*
DSU https://leetcode.com/problems/delete-nodes-and-return-forest/submissions/1299279790/

Time: O(n)
Space: O(H + D), H is the height of the tree and D is the size of to_delete

https://leetcode.com/problems/delete-nodes-and-return-forest/submissions/1299870884/

Time: O(n)
Space: O(H + D)

*/

public class Solution {
    HashSet<int> nodesToDelete;
    List<TreeNode> result;

    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        nodesToDelete = new(to_delete);

        result = new List<TreeNode>();

        Dfs(root, true);

        return result;
    }
    private TreeNode Dfs(TreeNode root, bool isRootDeleted){
        if(root == null) return null;
        bool deleted = nodesToDelete.Contains(root.val);
        if(isRootDeleted && !deleted){
            result.Add(root);
        }
        root.left = Dfs(root.left, deleted);
        root.right = Dfs(root.right, deleted);
        return deleted ? null : root;
    }

}
public class Solution {
    DisjointSet dsu = new();
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        HashSet<int> deletedNodes = new(to_delete);
        List<TreeNode> result = new List<TreeNode>();
        if (!deletedNodes.Contains(root.val)) {
            result.Add(root);
        }

        ConnectComponents(root, deletedNodes, result);
        
        return result;
    }

    public TreeNode ConnectComponents(TreeNode root, HashSet<int> deletedNodes, List<TreeNode> result) {
        if (root == null) {
            return null;
        }

        root.left = ConnectComponents(root.left, deletedNodes, result);
        root.right = ConnectComponents(root.right, deletedNodes, result);

        if (deletedNodes.Contains(root.val)) {
            if (root.left != null) {
                result.Add(root.left);
            }
            if (root.right != null) {
                result.Add(root.right);
            }
            return null;
        }

        return root;
    }
    public class DisjointSet{

        Dictionary<TreeNode, int> rank;
        public Dictionary<TreeNode, TreeNode> root;

        public DisjointSet(){
            rank = new();
            root = new();
        }

        public void Add(TreeNode element){
            if (!root.ContainsKey(element))
            {
                rank[element] = 1;
                root[element] = element;
            }
        }

        public void Union(TreeNode x, TreeNode y){
            var rootX = Find(x);
            var rootY = Find(y);

            if (!rootX.Equals(rootY))
            {
                int rankX = rank[rootX];
                int rankY = rank[rootY];

                if (rankX > rankY)
                {
                    root[rootY] = rootX;
                }
                else if (rankX < rankY)
                {
                    root[rootX] = rootY;
                }
                else
                {
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }
            }
        }

        public TreeNode Find(TreeNode x){
            if(root[x] == x){
                return root[x];
            }
            return root[x] = Find(root[x]);
        }
    }
}