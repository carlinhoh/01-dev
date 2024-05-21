/*
Depth https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/submissions/1264347250/

Time: O(h)
Space: O(1)

Two pointers https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/submissions/1264344167/

Time: O(h)
Space: O(1)

https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/submissions/1242833161/

Time: O(n)
Space: O(d), where d is the number of unique nodes in the path between p and q. O(n) in case of a degenerate (or pathological) tree (each parent node has only one associated child node).
*/

public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {
        int depthP = GetDepth(p), depthQ = GetDepth(q);

        while(depthP > depthQ){
            p = p.parent;
            depthP--;
        }
        while(depthQ > depthP){
            q = q.parent;
            depthQ--;
        }

        while(q != p){
            q = q.parent;
            p = p.parent;
        }
        return q;
    }

    private int GetDepth(Node node){
        int depth = 0;
        while(node != null){
            depth++;
            node = node.parent;
        }
        return depth;
    }
}
public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {
        Node p1 = p, p2 = q;
        while(p1 != p2){
            p1 = p1 == null ? p : p1.parent;
            p2 = p2 == null ? q : p2.parent;
        }
        return p1;
    }
}

public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {

        HashSet<int> seen = new();

        while(p != null || q != null){
            if(p != null){
                if(seen.Contains(p.val)){
                    return p;
                }
                seen.Add(p.val);
                p = p.parent;
            }
            if(q != null){
                if(seen.Contains(q.val)){
                    return q;
                }
                seen.Add(q.val);
                q = q.parent;
            }
        }
        
        return null;
    }
}