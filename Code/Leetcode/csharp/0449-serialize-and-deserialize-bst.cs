/*
Dfs Cleaner https://leetcode.com/problems/serialize-and-deserialize-bst/submissions/1272824397/
Dfs approach https://leetcode.com/problems/serialize-and-deserialize-bst/submissions/1272819871/

Time: O(n)
Space: O(n)
*/

public class Codec {
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null){
            return "N ";
        }
        else{
            return root.val.ToString() + " " + serialize(root.left) + serialize(root.right);
        }
    }
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        return Dfs(new Queue<string>(data.Split(" ")));
    }
    private TreeNode Dfs(Queue<string> q) {
        var s = q.Dequeue();
        if(s == "N"){
            return null;
        }
        else{
            return new TreeNode(Int32.Parse(s), Dfs(q), Dfs(q));
        }
    }
}

public class Codec {
    StringBuilder sb;
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        sb = new();

        Dfs(root);

        if(sb.Length > 0) sb.Length--;

        return sb.ToString();
        //retirar o ultimo
    }

    public void Dfs(TreeNode root){
        if(root == null){
            sb.Append("n,");
        }
        else{
            sb.Append(root.val).Append(",");
            Dfs(root.left);
            Dfs(root.right);
        }
    }

    // Decodes your encoded data to tree.
   public TreeNode deserialize(string data) {
        if (string.IsNullOrEmpty(data)) return null;
        string[] nodes = data.Split(',');
        int index = 0;
        return DfsDeserialize(nodes, ref index);
    }

    private TreeNode DfsDeserialize(string[] nodes, ref int index) {
        if (index >= nodes.Length || nodes[index] == "n") {
            index++;
            return null;
        }

        TreeNode root = new TreeNode(int.Parse(nodes[index]));
        index++;
        root.left = DfsDeserialize(nodes, ref index);
        root.right = DfsDeserialize(nodes, ref index);

        return root;
    }
}