/*
https://leetcode.com/problems/add-to-array-form-of-integer/submissions/1217593953/

Time: O(Max(N, LogK))
Space: O(Max(N, LogK))
*/

public class Solution {
    public IList<int> AddToArrayForm(int[] num, int k) {
        if(k==0){
            return new List<int>(num);
        }

        List<int> res = new();

        int sizeNum = num.Length;
        
        while(--sizeNum>=0 || k>0){
            if(sizeNum>=0){
                k += num[sizeNum];
            }
            res.Add(k%10);
            k /=10;
        }
        
        res.Reverse();
        return res;
    }
}