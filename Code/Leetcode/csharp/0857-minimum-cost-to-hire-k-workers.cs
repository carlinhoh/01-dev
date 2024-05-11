/*
https://leetcode.com/problems/minimum-cost-to-hire-k-workers/submissions/1255428496/

Time: O(nlogn +  nlogk)
Space: O(n + k)
*/

public class Solution {
    public double MincostToHireWorkers(int[] quality, int[] wage, int K) {
        var workers = new (double ratio, double quality)[quality.Length];
        for (int i = 0; i < quality.Length; ++i) {
            workers[i] = ((double)wage[i] / quality[i], quality[i]);
        }

        Array.Sort(workers, (a, b) => a.ratio.CompareTo(b.ratio));
        double result = double.MaxValue, qualitySum = 0;
        var maxHeap = new PriorityQueue<double, double>();

        foreach (var worker in workers) {
            qualitySum += worker.quality;

            maxHeap.Enqueue(-worker.quality, -worker.quality);

            if (maxHeap.Count > K) {
                qualitySum += maxHeap.Dequeue();
            }

            if (maxHeap.Count == K) {
                result = Math.Min(result, qualitySum * worker.ratio);
            }
        }
        return result;
    }
}