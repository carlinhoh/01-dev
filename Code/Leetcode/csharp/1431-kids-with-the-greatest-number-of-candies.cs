/*
https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/submissions/1219483750/

Time: O(N)
Space: O(1)
*/

public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        
        int maxNum = 0;

        foreach(var candy in candies){
            maxNum = Math.Max(maxNum, candy);
        }

        bool[] res = new bool[candies.Length];

        for(int i=0;i<candies.Length;i++){
            if(candies[i]+extraCandies>=maxNum){
                res[i] = true;
            }
        }

        return res;
    }
}