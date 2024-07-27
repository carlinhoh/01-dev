/*
https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/submissions/1335145613/
Time: O(n²)
Space: O(n³)
*/
public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int INF = 1000000007;
        int[,] distanceMatrix = new int[n, n];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                distanceMatrix[i, j] = i == j ? 0 : INF;
            }
        }

        foreach (var edge in edges) {
            int start = edge[0], end = edge[1], weight = edge[2];
            distanceMatrix[start, end] = weight;
            distanceMatrix[end, start] = weight;
        }

        Floyd(n, distanceMatrix);
        return GetCityWithFewestReachable(n, distanceMatrix, distanceThreshold);
    }

    void Floyd(int n, int[,] distanceMatrix) {
        for (int k = 0; k < n; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    distanceMatrix[i, j] = Math.Min(
                        distanceMatrix[i, j],
                        distanceMatrix[i, k] + distanceMatrix[k, j]
                    );
                }
            }
        }
    }

    int GetCityWithFewestReachable(int n, int[,] distanceMatrix, int distanceThreshold) {
        int cityWithFewestReachable = -1, fewestReachableCount = n;

        for (int i = 0; i < n; i++) {
            int reachableCount = 0;
            for (int j = 0; j < n; j++) {
                if (i != j && distanceMatrix[i, j] <= distanceThreshold) {
                    reachableCount++;
                }
            }
            if (reachableCount <= fewestReachableCount) {
                fewestReachableCount = reachableCount;
                cityWithFewestReachable = i;
            }
        }
        return cityWithFewestReachable;
    }
}
