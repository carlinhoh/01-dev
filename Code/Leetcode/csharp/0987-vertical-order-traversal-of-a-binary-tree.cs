/*
Group by columns https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/submissions/1265068100/

Time: O(NlogN/k)
Space: O(N)


https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/submissions/1265065791/

Time: O(NlogN)
Space: O(N)
*/
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        if (root == null) return new List<IList<int>>();

        var columnTable = new Dictionary<int, List<(int row, int val)>>();
        var queue = new Queue<(TreeNode node, int row, int column)>();
        queue.Enqueue((root, 0, 0));

        int minColumn = 0, maxColumn = 0;

        while (queue.Count > 0) {
            var (node, row, column) = queue.Dequeue();
            if (node != null) {
                if (!columnTable.ContainsKey(column)) {
                    columnTable[column] = new List<(int row, int val)>();
                }
                columnTable[column].Add((row, node.val));

                minColumn = Math.Min(minColumn, column);
                maxColumn = Math.Max(maxColumn, column);

                queue.Enqueue((node.left, row + 1, column - 1));
                queue.Enqueue((node.right, row + 1, column + 1));
            }
        }

        var result = new List<IList<int>>();

        for (int col = minColumn; col <= maxColumn; col++) {
            columnTable[col].Sort((a, b) => a.row == b.row ? a.val.CompareTo(b.val) : a.row.CompareTo(b.row));
            var columnValues = new List<int>();
            foreach (var pair in columnTable[col]) {
                columnValues.Add(pair.val);
            }
            result.Add(columnValues);
        }

        return result;
    }
}

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null) return new List<IList<int>>();

        Dictionary<(int row, int column), List<int>> verticalStructure = new();
        Queue<(TreeNode node, (int row, int column))> queue = new();
        int minColumn = int.MaxValue;
        int maxColumn = int.MinValue;
        queue.Enqueue((root, (0,0)));

        while(queue.Count > 0){
            var currNode = queue.Dequeue();
            if(currNode.node != null){
                maxColumn = Math.Max(maxColumn, currNode.Item2.column);
                minColumn = Math.Min(minColumn, currNode.Item2.column);
                if(!verticalStructure.ContainsKey((currNode.Item2.row, currNode.Item2.column))){
                    verticalStructure.Add((currNode.Item2.row, currNode.Item2.column), new List<int>());
                }
                verticalStructure[(currNode.Item2.row, currNode.Item2.column)].Add(currNode.node.val);

                queue.Enqueue((currNode.node.left, (currNode.Item2.row + 1, currNode.Item2.column - 1)));
                queue.Enqueue((currNode.node.right, (currNode.Item2.row + 1, currNode.Item2.column + 1)));
            }
        }
         var columns = new Dictionary<int, List<int>>();

        for (int startColumn = minColumn; startColumn <= maxColumn; startColumn++) {
            for (int startRow = 0; startRow <= verticalStructure.Count; startRow++) {
                if (verticalStructure.ContainsKey((startRow, startColumn))) {
                    if (!columns.ContainsKey(startColumn)) {
                        columns[startColumn] = new List<int>();
                    }
                    var values = verticalStructure[(startRow, startColumn)];
                    values.Sort();
                    columns[startColumn].AddRange(values);
                }
            }
        }

        foreach (var column in columns.Values) {
            result.Add(column);
        }
        return result;
    }
}