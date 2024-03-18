/*
https://leetcode.com/problems/intersection-of-two-arrays-ii/submissions/1207372400/

Time: O(N+M)
Space: O(M), If the res Hashset does not count O(1)
*/
public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        int[] seen = new int[1001];
        List<int> res = new();

        foreach(var item in nums1){
            seen[item]++;
        }

        foreach(var item in nums2){
            if(seen[item]>0){
                res.Add(item);
                seen[item]--;
            }
        }
        return res.ToArray();
    }
}