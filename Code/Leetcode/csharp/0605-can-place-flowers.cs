/*
https://leetcode.com/problems/can-place-flowers/submissions/1217467768/

Time: O(N)
Space: O(1)
*/
public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        for(int i=0;i<flowerbed.Length && n>0;i++){            
            if(flowerbed[i]==0 && (i==0 || flowerbed[i-1] == 0) && (i==flowerbed.Length-1 || flowerbed[i+1]==0)){
                i++;
                n--;
            }          
        }
        return n == 0;
    }
}