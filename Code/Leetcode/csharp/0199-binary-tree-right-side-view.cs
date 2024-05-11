/*
Iterative https://leetcode.com/problems/binary-tree-right-side-view/submissions/1246870720/
Time: O(n)
Space: O(D), where D is the diameter of the tree (n/2 in the case of complete binary tree)

Recursive https://leetcode.com/problems/binary-tree-right-side-view/submissions/1246921889/
Time: O(n)
Space: O(H), where H is the tree height (n in the case of a skewed tree and log(n) in the case of a complete binary tree)

*/
public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        if(root == null){
            return new List<int>();
        }

        List<int> rightView = new();
        Queue<TreeNode> q = new();

        q.Enqueue(root);

        while(q.Count > 0 ){
            int levelNum = q.Count;
            for(int i = 1; i<=levelNum; i++){
                var curr = q.Dequeue();    
                if(i == levelNum){
                    rightView.Add(curr.val);
                }
                
                if(curr.left != null){
                    q.Enqueue(curr.left);
                }
                if(curr.right != null){
                    q.Enqueue(curr.right);
                }
            }
        }

        return rightView;
    }
}

public class Solution {

    List<int> rightSide;
    public IList<int> RightSideView(TreeNode root) {
       
       rightSide = new();
       
       if(root == null){
        return rightSide;
       }

       Dfs(root, 0);

       return rightSide;
    }

    public void Dfs(TreeNode node, int level){
        if(rightSide.Count == level){
            rightSide.Add(node.val);
        }

        if(node.right != null){
            Dfs(node.right, level + 1);
        }
        if(node.left != null){
            Dfs(node.left, level + 1);
        }
    }
}