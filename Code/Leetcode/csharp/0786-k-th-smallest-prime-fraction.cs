/*
https://leetcode.com/problems/k-th-smallest-prime-fraction/submissions/1254495669/

Time: O((n + k) logn)
Space: O(n)
*/
public class Solution {
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        var pq = new PriorityQueue<(int numeratorIndex, int denominatorIndex), double>();

        for (int i = 0; i < arr.Length - 1; i++) {
            pq.Enqueue((i, arr.Length - 1), arr[i] / (double)arr[arr.Length - 1]);
        }

        while (--k > 0) {
            var current = pq.Dequeue();
            int numeratorIndex = current.numeratorIndex;
            int denominatorIndex = current.denominatorIndex;

            if (denominatorIndex - 1 > numeratorIndex) {
                pq.Enqueue((numeratorIndex, denominatorIndex - 1), arr[numeratorIndex] / (double)arr[denominatorIndex - 1]);
            }
        }

        var smallest = pq.Dequeue();
        return new int[] { arr[smallest.numeratorIndex], arr[smallest.denominatorIndex] };
    }
}