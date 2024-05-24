/*
https://leetcode.com/problems/combinations/submissions/1266932728/

Time: O(n!/((k-1)! * (n-k)!))
Space: O(k)
*/
public class Solution {
    List<IList<int>> ans = new();
    public IList<IList<int>> Combine(int n, int k) {
        GetCombinations(1, n, k, new List<int>());
        return ans;
    }
    public void GetCombinations(int start, int end, int size, List<int> currList){
        if(currList.Count == size){
            ans.Add(new List<int>(currList));
            return;
        }
        for(int i = start;i <= end;i++){
            currList.Add(i);
            GetCombinations(i + 1, end, size, currList);
            currList.RemoveAt(currList.Count - 1);
        }
    }
}