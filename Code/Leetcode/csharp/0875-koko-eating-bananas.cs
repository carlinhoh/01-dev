/*
https://leetcode.com/problems/koko-eating-bananas/submissions/1466139243/

Time: O(n*log(m)), where m is piles.Max()
Space: O(1)
*/
public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int max = piles.Max();
        if(piles.Length == h){
            return max;
        }

        return BinarySearchMinEatingSpeed(piles, h, max);
    }

    public int BinarySearchMinEatingSpeed(int[] piles, int h, int max){
        int min = 1;
        while(min < max){
            int mid = min + (max - min)/2;
            if (CanEatAll(piles, h, mid)){
                max = mid; 
            }
            else{
                min = mid + 1;
            }
        }
        return min;
    }

    static bool CanEatAll(int[] piles, int h, int k)
    {
        int hours = 0;

        foreach (int pile in piles){
            hours += (int)Math.Ceiling((double)pile / k);
        }

        return hours <= h;
    }
}