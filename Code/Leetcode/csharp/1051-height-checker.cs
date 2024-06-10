/*
https://leetcode.com/problems/height-checker/submissions/1283791036/

Time: O(n)
Space: O(1)
*/

public class Solution {
    public int HeightChecker(int[] heights) {
        int[] frequency = new int[101];
        int j=0;
        int result = 0;
        for(int i=0;i<heights.Length;i++){
            ++frequency[heights[i]];
        }
        
        for(int i=0;i<frequency.Length;i++){
            while(frequency[i]>0){
               if(heights[j++] != i){
                  result++;
               } 
                --frequency[i];
            }
        }
        return result;
    }
}