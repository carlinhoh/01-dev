/*
https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree-iii/submissions/1242833161/

Time: O(n)
Space: O(d), where d is the number of unique nodes in the path between p and q. O(n) in case of a degenerate (or pathological) tree (each parent node has only one associated child node).
*/
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