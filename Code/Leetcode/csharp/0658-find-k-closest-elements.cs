/*
Binary Search with Sliding window https://leetcode.com/problems/find-k-closest-elements/submissions/1257257306/

Time: O(log(n-k) + k)
Space: O(1)

Binary Search + sliding window https://leetcode.com/problems/find-k-closest-elements/submissions/1257252738/

Time: O(logn + k)
Space: O(1)
*/

public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        int left = BinarySearchWindow(arr, k, x);
        List<int> ans = new();

        for(int i=left;i<left+k;i++){
            ans.Add(arr[i]);
        }

        return ans;
    }
    private int BinarySearchWindow(int[] arr, int k, int x){
        int left = 0;
        int right = arr.Length - k;

        while(left < right){
            int mid = left + (right - left)/2;
            if(x - arr[mid] > arr[mid + k] - x){
                left = mid + 1;
            }
            else{
                right = mid;
            }
        }
        return left;
    }
}

public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        if( k == arr.Length){
            return arr;
        }    

        int posLeft = BinarySearch(arr, x) - 1;
        int posRight = posLeft + 1;

        if(posLeft == arr.Length){
            return arr.TakeLast(k).ToList();
        }

        LinkedList<int> closestElements = new LinkedList<int>();

        while(posRight - posLeft - 1 < k){
            if(posLeft == -1){
                closestElements.AddLast(arr[posRight]);
                posRight++;
            }
            else if(posRight == arr.Length || Math.Abs(arr[posLeft] - x)  <= Math.Abs(arr[posRight] - x)){
                closestElements.AddFirst(arr[posLeft]);
                posLeft--;
            }
            else{
                closestElements.AddLast(arr[posRight]);
                posRight++;
            }
        }

        return closestElements.ToList();
    }

    public int BinarySearch(int[] arr, int x){
        int left = 0;
        int right = arr.Length - 1;

        while(left <= right){
            int mid = left + (right - left) /2;

            if(arr[mid] > x){
                right = mid - 1;
            }
            else if(arr[mid] < x){
                left = mid + 1;
            }
            else return mid;
        }
        return left;
    }

}

