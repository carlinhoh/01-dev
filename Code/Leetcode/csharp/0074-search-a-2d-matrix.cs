/*
https://leetcode.com/problems/search-a-2d-matrix/submissions/1466061810/

Time: O(log(mn))
Space: O(1)
*/
public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int n = matrix.Length;
        int m = matrix[0].Length;
        
        if(n == 0 | m == 0){
            return false;
        }

        int left = 0;
        int right = n * m - 1;

        while(left <= right){
            int mid = left + (right - left)/2;

            int row = mid / m;
            int col = mid % m;

            if(matrix[row][col] == target){
                return true;
            }
            else if(matrix[row][col] < target){
                left = mid + 1;
            }
            else{
                right = mid - 1;
            }
        }

        return false;
    }
}