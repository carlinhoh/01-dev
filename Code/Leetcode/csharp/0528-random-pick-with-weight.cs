/*
https://leetcode.com/problems/random-pick-with-weight/submissions/1243784370/

Time: Constructor = O(n), PickIndex = O(logn)
Space: Constructor = O(n), PickIndex = O(1)
*/
    public class Solution {

    int totalSum;
    int[] possibilities;
    Random random;

    public Solution(int[] w) {

        possibilities = new int[w.Length];

        for(int i=0;i<w.Length;i++){
            totalSum += w[i];
            possibilities[i] += totalSum;
        }
        random = new Random();
    }

    public int PickIndex() {

        double randomTarget = totalSum * random.NextDouble();

        int left = 0;
        int right = possibilities.Length;

        while(left<right){
            int mid = left + (right - left)/2;

            if(randomTarget > possibilities[mid]){
                left = mid + 1;
            }
            else{
                right = mid;
            }
        }

        return left; 
    }
}