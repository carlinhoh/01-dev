/*
BFS https://leetcode.com/problems/diagonal-traverse-ii/submissions/1264940662/

Time: O(n)
Space: O(sqrt(n)), in a grid with n the largest diagonal would be sqrt(n)


HashMap https://leetcode.com/problems/diagonal-traverse-ii/submissions/1264883504/

Time: O(n) where n is the number of elements in nums
Space: O(n)
*/

public class Solution {
    public int[] FindDiagonalOrder(IList<IList<int>> nums) {
        Queue<(int row, int column)> q = new();
        q.Enqueue((0,0));
        List<int> res = new();
        while(q.Any()){
            (int row, int column) = q.Dequeue();
            res.Add(nums[row][column]);
            if(column == 0 && row + 1 < nums.Count){
                q.Enqueue((row+1, column));
            }
            if(column + 1 < nums[row].Count){
                q.Enqueue((row, column+1));
            }
        }
        return res.ToArray();
    }
}
public class Solution {
    public int[] FindDiagonalOrder(IList<IList<int>> nums) {
        Dictionary<int, List<int>> secDiagonals = new();
        int size = 0;
        for(int i=nums.Count-1;i>=0; i--){
            for(int j=0;j<nums[i].Count;j++){
                int diagonal = i + j;
                if(!secDiagonals.ContainsKey(diagonal)){
                    secDiagonals.Add(diagonal, new List<int>());
                }                
                secDiagonals[diagonal].Add(nums[i][j]);
                size++;
            }
        }

        int[] res = new int[size];
        int diagonalIdx = 0;
        int elementIdx = 0;

        while(secDiagonals.ContainsKey(diagonalIdx)){
            foreach(var elem in secDiagonals[diagonalIdx]){
                res[elementIdx++] = elem;
            }
            diagonalIdx++;
        }

        return res;
    }
}