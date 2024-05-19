/*
PriorityQueue + sort https://leetcode.com/problems/car-pooling/submissions/1261724825/

Time: O(NlogN)
Space: O(N)

Bucket Sort https://leetcode.com/problems/car-pooling/submissions/1261729136/

Time: O(Max(N, 1001))
Space: O(1)
*/
public class Solution {
    private const int _maxValue = 1000;
    public bool CarPooling(int[][] trips, int capacity) {
        int[] bucket = new int[_maxValue + 1];
        int min = _maxValue;
        int max = 0;

        foreach(int[] trip in trips){
            bucket[trip[1]] += trip[0];
            bucket[trip[2]] -= trip[0];
            if(trip[1] < min) { min = trip[1]; }
            if(trip[2] > max) { max = trip[2]; }
        }

        for(int passengers = 0; min<=max; ++min){
            passengers += bucket[min];
            if(passengers > capacity){
                return false;
            }
        }

        return true;
    }
}

public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        Array.Sort(trips, (a, b) => a[1].CompareTo(b[1]));

        if(trips[0][0] > capacity){
            return false;
        }
        PriorityQueue<(int passengers, int endPoint), int> pq = new();

        pq.Enqueue((trips[0][0], trips[0][2]), trips[0][2]);

        int currCapacity = trips[0][0];

        for(int i =1;i<trips.Length;i++){
            while (pq.Count > 0 && pq.Peek().endPoint <= trips[i][1]) {
               (int currPassengers, int currEndpoint) = pq.Dequeue();
               currCapacity -= currPassengers;
            }
            pq.Enqueue((trips[i][0], trips[i][2]), trips[i][2]);
            currCapacity += trips[i][0];
            if(currCapacity > capacity) return false;
        }

        return true;
    }
}