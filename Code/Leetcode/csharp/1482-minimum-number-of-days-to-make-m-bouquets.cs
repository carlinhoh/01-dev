/*
https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/submissions/1293829202/

Time: O(N * log(max(bloomDay)))
Sapce: O(1)
*/
class Solution{
    private int GetNumOfBouquets(int[] bloomDay, int mid, int k){
        int numOfBouquets = 0;
        int count = 0;

        for (int i = 0; i < bloomDay.Length; i++){
            if (bloomDay[i] <= mid){
                count++;
            } else {
                count = 0;
            }

            if (count == k){
                numOfBouquets++;
                count = 0;
            }
        }

        return numOfBouquets;
    }

    public int MinDays(int[] bloomDay, int m, int k){
        int start = 0;
        int end = 0;
        foreach (int day in bloomDay){
            end = Math.Max(end, day);
        }

        int minDays = -1;
        while (start <= end){
            int mid = (start + end) / 2;

            if (GetNumOfBouquets(bloomDay, mid, k) >= m){
                minDays = mid;
                end = mid - 1;
            } else {
                start = mid + 1;
            }
        }

        return minDays;
    }
}