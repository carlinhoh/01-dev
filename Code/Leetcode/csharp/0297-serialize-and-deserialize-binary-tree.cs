/*
https://leetcode.com/problems/serialize-and-deserialize-binary-tree/submissions/1248543042/

Time: O(n)
Space: O(n)
*/
public class Codec {
    StringBuilder sb = new();
    public string serialize(TreeNode root) {
        PreOrder(root, sb);
        if (sb.Length > 0) sb.Length--;
        return sb.ToString();
    }

    private void PreOrder(TreeNode node, StringBuilder sb) {
        if (node == null) {
            sb.Append("n,");
        } else {
            sb.Append(node.val).Append(",");
            PreOrder(node.left, sb);
            PreOrder(node.right, sb);
        }
    }

    public TreeNode deserialize(string data) {
        Queue<string> nodes = new Queue<string>(data.Split(','));
        return PreOrder(nodes);
    }
    public TreeNode PreOrder(Queue<string> nodes){
        if (nodes.Count == 0) return null;

        string val = nodes.Dequeue();
        if (val == "n") return null;

        TreeNode node = new TreeNode(int.Parse(val));
        node.left = PreOrder(nodes);
        node.right = PreOrder(nodes);

        return node;
    }
}