/*
Quick select https://leetcode.com/problems/k-closest-points-to-origin/submissions/1245983923/
Time: O(n), can be O(n²) if pivot is the largest or smallest element
Space: O(n)

Max Heap https://leetcode.com/problems/k-closest-points-to-origin/submissions/1245925205/
Time: O(nlogk)
Space: O(k)

Sort https://leetcode.com/problems/k-closest-points-to-origin/submissions/1245879096/
Time: O(nlogn)
Space: O(n)
*/

public class Solution {
    Random random;
    public int[][] KClosest(int[][] points, int k) {
        random = new();

        if (k >= points.Length) {
            return points;
        }

        QuickSelect(points, 0, points.Length-1, k);

        int[][] result = new int[k][];
        Array.Copy(points, result, k);
        return result;

    }

    private void QuickSelect(int[][]  points, int left, int right, int k){
        if(left >= right) return;

        int pivotIndex = Partition(points, left, right);

        if(pivotIndex == k ) return;

        if(pivotIndex < k){
            QuickSelect(points, pivotIndex + 1, right, k);
        }
        else{
            QuickSelect(points, left, pivotIndex - 1, k);
        }
    }

    private int Partition(int[][] points, int left, int right){
        int pivotIndex = random.Next(left, right);
        int[] pivot = points[pivotIndex]; 
        int pivotDist = DistanceSquared(pivot);

        Swap(points, pivotIndex, right);
        pivotIndex = right;

        int i = left;

        for(int j = left; j < right; j++ ){
            if(DistanceSquared(points[j]) < pivotDist){
                Swap(points, i, j);
                i++;
            }
        }

        Swap(points, i, pivotIndex);

        return i;
    }
    private void Swap(int[][] points, int i, int j) {
        int[] temp = points[i];
        points[i] = points[j];
        points[j] = temp;
    }
    private int DistanceSquared(int[] point) {
        return  point[0] *  point[0] + point[1] * point[1];
    }
}
 public int[][] KClosest(int[][] points, int k) {
        if(k > points.Length){
            return points;
        }

        PriorityQueue<int[], int> pq = new(Comparer<int>.Create((x,y) => y.CompareTo(x)));

        foreach(var p in points){
            var x = p[0];
            var y = p[1];

            if(pq.Count < k){
                pq.Enqueue(p, x*x + y*y);
            }
            else{
                pq.EnqueueDequeue(p, x*x + y*y);
            }
        }

        int[][] res = new int[k][];

        while(pq.Count>0){
            res[k-pq.Count] = pq.Dequeue();
        }
        return res;
    }

public class Solution {
    public int[][] KClosest(int[][] points, int k) {
       Array.Sort(points, (a, b) => {
            int distA = a[0] * a[0] + a[1] * a[1];
            int distB = b[0] * b[0] + b[1] * b[1];

            return distA.CompareTo(distB);
        });
        
        int[][] ans = points.Take(k).ToArray();

        return ans;
    }
}