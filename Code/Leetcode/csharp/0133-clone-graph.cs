/*
https://leetcode.com/problems/clone-graph/submissions/1212236608/

Time: O(n + m)
Space: O(n)
*/

public class Solution {
    public Node CloneGraph(Node node) {
       if (node == null) {
            return null;
        }

        Dictionary<Node, Node> clones = new Dictionary<Node, Node>();
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);
        clones[node] = new Node(node.val, new List<Node>());

        while (queue.Count > 0) {
            Node current = queue.Dequeue();
            foreach (var neighbor in current.neighbors) {
                if (!clones.ContainsKey(neighbor)) {
                    clones[neighbor] = new Node(neighbor.val, new List<Node>());
                    queue.Enqueue(neighbor);
                }
                clones[current].neighbors.Add(clones[neighbor]);
            }
        }
        return clones[node];
    }
}