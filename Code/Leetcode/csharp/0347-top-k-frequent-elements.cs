/**
#blind-75
#neetcode-150

Quick Select https://leetcode.com/problems/top-k-frequent-elements/submissions/1276944777/

Time: O(N²), Average O(N)
Space: O(N)

https://leetcode.com/problems/top-k-frequent-elements/submissions/1151963042/

Time: O(N)
Space: O(N)
**/


public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> frequencyDict = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (frequencyDict.ContainsKey(num)) {
                frequencyDict[num]++;
            } else {
                frequencyDict[num] = 1;
            }
        }

        List<(int element, int frequency)> frequencyList = new List<(int, int)>();
        foreach (var pair in frequencyDict) {
            frequencyList.Add((pair.Key, pair.Value));
        }

        QuickSelect(frequencyList, 0, frequencyList.Count - 1, k - 1);

        int[] result = new int[k];

        for (int i = 0; i < k; i++) {
            result[i] = frequencyList[i].element;
        }

        return result;
    }

    private void QuickSelect(List<(int element, int frequency)> nums, int left, int right, int k) {
        if (left == right) {
            return;
        }

        int pivot = Partition(nums, left, right);

        if (pivot > k) {
            QuickSelect(nums, left, pivot - 1, k);
        } else if (pivot < k) {
            QuickSelect(nums, pivot + 1, right, k);
        }
    }

    private int Partition(List<(int element, int frequency)> nums, int left, int right) {
        var pivot = nums[right];
        int p = left;

        for (int i = left; i < right; i++) {
            if (nums[i].frequency > pivot.frequency) {
                Swap(nums, p, i);
                p++;
            }
        }

        Swap(nums, p, right);

        return p;
    }

    private void Swap(List<(int element, int frequency)> nums, int x, int y) {
        var temp = nums[x];
        nums[x] = nums[y];
        nums[y] = temp;
    }
}
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        if(k==nums.Length){
            return nums;
        }

        Dictionary<int, int> freq = new();

        foreach(var num in nums){
            if(!freq.TryAdd(num, 1)){
                freq[num]++;
            }
        }
        int n = nums.Length+1;
        List<List<int>> freqList = new();

        for(int i=0;i<n;i++){
            List<int> temp = new();
            freqList.Add(temp);
        }

        foreach(var item in freq){
            freqList[item.Value].Add(item.Key);
        }
       
        List<int> topk = new List<int>(k);

        for(int i=freqList.Count-1;i>0;i--){
            if(freqList[i].Count != 0){
                topk.AddRange(freqList[i]);
            }
            if(topk.Count==k){
                return topk.ToArray();
            }
        }
        return default;
    }
}

// Max Heap solution
// https://leetcode.com/problems/top-k-frequent-elements/submissions/1151077745/
// Time: O(N*LogK)
// Space: O(N+K)
// public class Solution {
//     public int[] TopKFrequent(int[] nums, int k) {
        
//         if(nums.Length <= k){
//             return nums;
//         }

//         Dictionary<int, int> dic = new();

//         foreach(var num in nums){
//             if(dic.ContainsKey(num)){
//                 dic[num]++;
//             }
//             dic.TryAdd(num, 1);
//         }
        
//         PriorityQueue<int, int> q = new();

//         foreach(var item in dic){
//             if(q.Count<k){
//                 q.Enqueue(item.Key, item.Value);
//             }
//             else{
//                 q.EnqueueDequeue(item.Key, item.Value);
//             }
//         }

//         int[] topk = new int[k];

//         while(q.Count>0){
//             topk[k-q.Count] = q.Dequeue();
//         }
//         return topk;
//     }
// }