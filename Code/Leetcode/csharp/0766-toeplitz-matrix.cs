/*
https://leetcode.com/problems/toeplitz-matrix/submissions/1243732001/

Time: O(n*m)
Space: O(1)
*/


public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        int n = matrix.Length;
        int m = matrix[0].Length;

        for(int i=0;i<n;i++){
            for(int j=0;j<m;j++){
                if(i+1< n && j+1<m && matrix[i][j] != matrix[i+1][j+1]){
                    return false;
                }
            }
        }

        return true;
    }
}