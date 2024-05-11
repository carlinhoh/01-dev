/*
https://leetcode.com/problems/combination-sum/submissions/1252991765/

Time: O(N^(T/M + 1)), where T is the target value and M the minimal value among the candidates
Space: O(T/M)
*/

public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
       List<IList<int>> res = new();
       LinkedList<int> path = new();

       Dfs(target, path, 0, candidates, res);

       return res;
    }

    protected void Dfs(int target, LinkedList<int> path, int index, int[] candidates, List<IList<int>> res){
        if(target==0){
            res.Add(new List<int>(path));
            return;
        }
        else if(target<0){
            return;
        }
        for(int i = index; i<candidates.Length;i++){
            path.AddLast(candidates[i]);
            Dfs(target-candidates[i], path, i, candidates, res);
            path.RemoveLast();
        }
    }
    
}
