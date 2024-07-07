/*
https://leetcode.com/problems/water-bottles/submissions/1313332637/
Time: O(1)
Space: O(1)

*/
public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        return numBottles + (numBottles-1) / (numExchange - 1);
    }
}