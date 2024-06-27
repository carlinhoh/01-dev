/*
https://leetcode.com/problems/find-center-of-star-graph/submissions/1301553250/

Time: O(1)
Space: O(1)
*/
public class Solution {
    public int FindCenter(int[][] edges) {
        if (edges[0][0] == edges[1][0] || edges[0][0] == edges[1][1]) {
            return edges[0][0];
        } else {
            return edges[0][1];
        }
    }
}