/*
https://leetcode.com/problems/intersection-of-two-arrays/submissions/1207362969/

Time:O(N)
Space: O(N), If the res Hashset does not count O(1)
*/
public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        int[] seen = new int[1000];
        HashSet<int> res = new();

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

/*
public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> set = new(nums1);
        HashSet<int> res = new();
        foreach(var item in nums2){
            if(set.Contains(item)){
                res.Add(item);
            }
        }
        return res.ToArray();
    }
*/