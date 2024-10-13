/*
https://leetcode.com/problems/maximum-units-on-a-truck/submissions/1421401048/

Time: O(nlogn)
Space: O(logn)
*/
public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        Array.Sort(boxTypes, (a, b) => b[1].CompareTo(a[1]));
        int maxUnits = 0;
        int boxesTaken = 0;
        for(int i=0;i<boxTypes.Length && truckSize > 0;i++){
            boxesTaken = Math.Min(truckSize, boxTypes[i][0]);
            truckSize -= boxesTaken;
            maxUnits += boxesTaken * boxTypes[i][1];
        }
        return maxUnits;
    }
}