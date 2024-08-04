/*
https://leetcode.com/problems/make-two-arrays-equal-by-reversing-subarrays/submissions/1342423597

Time: O(n)
Space: O(n)
*/
public class Solution{
    public bool CanBeEqual(int[] target, int[] arr){
        Dictionary<int, int> arrFreq = new Dictionary<int, int>();
        foreach (int num in arr)
        {
            if (arrFreq.ContainsKey(num))
            {
                arrFreq[num]++;
            }
            else
            {
                arrFreq[num] = 1;
            }
        }

        foreach (int num in target)
        {
            if (!arrFreq.ContainsKey(num))
            {
                return false;
            }

            arrFreq[num]--;
            if (arrFreq[num] == 0)
            {
                arrFreq.Remove(num);
            }
        }
        return arrFreq.Count == 0;
    }
}
