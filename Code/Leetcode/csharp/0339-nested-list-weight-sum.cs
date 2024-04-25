/*
https://leetcode.com/problems/nested-list-weight-sum/submissions/1241987787/

Time:O(n)
Space:O(n)
*/
public class Solution {
    public int DepthSum(IList<NestedInteger> nestedList) {
        
        int sum = Dfs(nestedList, 1);

        return sum;   
    }

    public int Dfs(IList<NestedInteger> nestedList, int depth){
        int sum = 0;
        foreach(var nested in nestedList){
            if(nested.IsInteger()){
                sum += nested.GetInteger() * depth;
            } 
            else{
                sum += Dfs(nested.GetList(), depth+1);
            }
        }
        return sum;
    }
}