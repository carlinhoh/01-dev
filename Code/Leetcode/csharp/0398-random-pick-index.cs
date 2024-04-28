/*
https://leetcode.com/problems/random-pick-index/submissions/1243831865/

Time: Constructor = O(n), Pick = O(1)
Space: Constructor = O(n), Pick = O(1)
*/
public class Solution {

    Dictionary<int, List<int>> indexMap;
    Random random;

    public Solution(int[] nums) {
        indexMap =  new();
        random = new();

        for(int i=0;i<nums.Length;i++){
            if(indexMap.ContainsKey(nums[i])){
                indexMap[nums[i]].Add(i);
            }
            else{
                indexMap.Add(nums[i], new List<int>() {i});
            }
        }
    }
    
    public int Pick(int target) {
        var indexesOfNum = indexMap[target];

        var randomIndex = random.Next(indexesOfNum.Count);

        return indexesOfNum[randomIndex];
    }
}