/// <summary>
/// Class for performing depth-first search (DFS) traversals on a binary tree.
/// </summary>
public class DepthFirstSearch
{
    /// <summary>
    /// Performs recursive preorder traversal on the binary tree starting from the specified node.
    /// </summary>
    /// <param name="node">The starting node for traversal.</param>
    /// <returns>The list of node values in preorder traversal.</returns>
    /// <remarks>Preorder traversal is useful for creating a copy of the tree or exploring paths before processing child nodes.</remarks>
    public List<int> PreOrderTraversalRecursive(TreeNode node)
    {
        List<int> result = new List<int>();
        PreorderRecursiveHelper(node, result);
        return result;
    }

    /// <summary>
    /// Helper method for recursive preorder traversal.
    /// </summary>
    private void PreorderRecursiveHelper(TreeNode node, List<int> result)
    {
        if (node == null) return;
        result.Add(node.val);
        PreorderRecursiveHelper(node.left, result);
        PreorderRecursiveHelper(node.right, result);
    }

    /// <summary>
    /// Performs iterative preorder traversal on the binary tree starting from the specified node.
    /// </summary>
    /// <param name="node">The starting node for traversal.</param>
    /// <returns>The list of node values in preorder traversal.</returns>
    /// <remarks>Preorder traversal is useful for creating a copy of the tree or exploring paths before processing child nodes.</remarks>
    public List<int> PreorderTraversalIterative(TreeNode node)
    {
        if (node == null) return new List<int>();

        var result = new List<int>();
        var stack = new Stack<TreeNode>();

        stack.Push(node);

        while (stack.Count > 0)
        {
            TreeNode current = stack.Pop();
            result.Add(current.val);
            if (current.right != null) stack.Push(current.right);
            if (current.left != null) stack.Push(current.left);
        }
        return result;
    }

    /// <summary>
    /// Performs recursive inorder traversal on the binary tree starting from the specified node.
    /// </summary>
    /// <param name="node">The starting node for traversal.</param>
    /// <returns>The list of node values in inorder traversal.</returns>
    /// <remarks>Inorder traversal is useful for obtaining elements of a binary search tree (BST) in ascending order.</remarks>
    public List<int> InOrderTraversalRecursive(TreeNode node)
    {
        List<int> result = new List<int>();
        InorderRecursiveHelper(node, result);
        return result;
    }

    /// <summary>
    /// Helper method for recursive inorder traversal.
    /// </summary>
    private void InorderRecursiveHelper(TreeNode node, List<int> result)
    {
        if (node == null) return;
        InorderRecursiveHelper(node.left, result);
        result.Add(node.val);
        InorderRecursiveHelper(node.right, result);
    }

    /// <summary>
    /// Performs iterative inorder traversal on the binary tree starting from the specified node.
    /// </summary>
    /// <param name="node">The starting node for traversal.</param>
    /// <returns>The list of node values in inorder traversal.</returns>
    /// <remarks>Inorder traversal is useful for obtaining elements of a binary search tree (BST) in ascending order.</remarks>
    public List<int> InOrderTraversalIterative(TreeNode node)
    {
        List<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = node;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            current = stack.Pop();
            result.Add(current.val);
            current = current.right;
        }
        return result;
    }

    /// <summary>
    /// Performs recursive postorder traversal on the binary tree starting from the specified node.
    /// </summary>
    /// <param name="node">The starting node for traversal.</param>
    /// <returns>The list of node values in postorder traversal.</returns>
    /// <remarks>Postorder traversal is useful for safely deleting the tree or when processing child nodes before processing the node itself.</remarks>
    public List<int> PostOrderTraversalRecursive(TreeNode node)
    {
        List<int> result = new List<int>();
        PostorderRecursiveHelper(node, result);
        return result;
    }

    /// <summary>
    /// Helper method for recursive postorder traversal.
    /// </summary>
    private void PostorderRecursiveHelper(TreeNode node, List<int> result)
    {
        if (node == null) return;
        PostorderRecursiveHelper(node.left, result);
        PostorderRecursiveHelper(node.right, result);
        result.Add(node.val);
    }

    /// <summary>
    /// Performs iterative postorder traversal on the binary tree starting from the specified node.
    /// </summary>
    /// <param name="node">The starting node for traversal.</param>
    /// <returns>The list of node values in postorder traversal.</returns>
    /// <remarks>Postorder traversal is useful for safely deleting the tree or when processing child nodes before processing the node itself.</remarks>
    public List<int> PostOrderTraversalIterative(TreeNode node)
    {
        if (node == null) return new List<int>();
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        var output = new Stack<int>();
        stack.Push(node);

        while (stack.Count > 0)
        {
            TreeNode current = stack.Pop();
            output.Push(current.val);
            if (current.left != null) stack.Push(current.left);
            if (current.right != null) stack.Push(current.right);
        }

        while (output.Count > 0)
        {
            result.Add(output.Pop());
        }
        return result;
    }
}