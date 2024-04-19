/*
https://leetcode.com/problems/binary-tree-vertical-order-traversal/submissions/1236922366/

Time: O(n)
Space: O(n)
*/
public class Solution {
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null) return new List<IList<int>>();

        Dictionary<int, List<int>> verticalStructure = new();
        Queue<(TreeNode node, int column)> queue = new();

        queue.Enqueue((root, 0));

        while(queue.Count > 0){
            var currNode = queue.Dequeue();

            if(currNode.node != null){
                if(!verticalStructure.ContainsKey(currNode.column)){
                    verticalStructure.Add(currNode.column, new List<int>());
                }
                verticalStructure[currNode.column].Add(currNode.node.val);

                queue.Enqueue((currNode.node.left, currNode.column-1));
                queue.Enqueue((currNode.node.right, currNode.column+1));
            }
        } 

        int minColumn = verticalStructure.Keys.Min();
        int maxColumn = verticalStructure.Keys.Max();

        for(int i=minColumn;i<=maxColumn;i++){
            result.Add(verticalStructure[i]);
        }     
        return result;
    }
}