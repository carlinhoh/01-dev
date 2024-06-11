/*
https://leetcode.com/problems/relative-sort-array/submissions/1284389767

Time: O(n + m)
Space: O(1)
*/
public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        int[] bucket = new int[1001];

        foreach (int num in arr1){
            bucket[num]++;
        }

        int[] res = new int[arr1.Length];
        int index = 0;

        foreach (int num in arr2){
            while (bucket[num] > 0) {
                res[index++] = num;
                bucket[num]--;
            }
        }

        for (int i = 0; i < bucket.Length; i++){
            while (bucket[i] > 0) {
                res[index++] = i;
                bucket[i]--;
            }
        }

        return res;
    }
}
