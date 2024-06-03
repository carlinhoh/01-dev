/*
https://leetcode.com/problems/first-bad-version/submissions/1275799675/

Time: O(logn)
Space: O(1)
*/
public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int left = 1;
        int right = n;

        while(left<right){
            int mid = left + (right - left)/2;
            if(!IsBadVersion(mid)){
                left = mid + 1;
            }
            else{
                right = mid;
            }
        }

        return left;
    }
}