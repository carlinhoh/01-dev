/*
https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/submissions/1223622684/

Time: O(k)
Space: O(1)
*/

public class Solution {
    public int MaxScore(int[] cardPoints, int k) {

        if(k >= cardPoints.Length){
            return cardPoints.Sum();
        }

        int left = 0 ;
        int totalSum = 0;
        int right = cardPoints.Length-1;

        for(int i=0;i<k;i++){
            totalSum += cardPoints[i]; 
        }

        int res = totalSum;

        while(left<k){
            totalSum -= cardPoints[k-1-left];
            totalSum += cardPoints[right];
            res = Math.Max(res, totalSum);
            left++;
            right--;
        }
        
        return res;
    }
}