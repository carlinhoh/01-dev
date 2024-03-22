/*
https://leetcode.com/problems/binary-tree-level-order-traversal/submissions/1211170117/

Time: O(N)
Space: O(N)
*/
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        
        if(root == null){
            return  new List<IList<int>>();
        }

        Queue<TreeNode> nodesQueue = new();

        nodesQueue.Enqueue(root);

        List<IList<int>> levelsList = new List<IList<int>>();

        while(nodesQueue.Count>0){
            int size = nodesQueue.Count;
            List<int> level = new();

            for(int i=0;i<size;i++){
                var currNode = nodesQueue.Dequeue();
                level.Add(currNode.val);

                if(currNode.left != null){
                    nodesQueue.Enqueue(currNode.left);
                }
                if(currNode.right != null){
                    nodesQueue.Enqueue(currNode.right);
                }
            }
            levelsList.Add(level);
        }

        return levelsList;
    }
}