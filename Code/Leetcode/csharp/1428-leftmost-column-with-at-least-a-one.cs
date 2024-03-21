/*
https://leetcode.com/problems/leftmost-column-with-at-least-a-one/submissions/1210391258/

Time: O(N+M)
Space: O(1)
*/

class Solution {
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix) {
        if(binaryMatrix == null){
            return -1;
        }
        IList<int> dimensions = binaryMatrix.Dimensions();

        int row = dimensions[0]-1;
        int col = dimensions[1]-1;
        int count = 0;

        int leftmostCol = -1;

        while(row>=0 && col>=0){
            if(binaryMatrix.Get(row,col) == 1){
                leftmostCol = col;
                col--;
            }
            else{
                row--;
            }
        }
        return leftmostCol;
    }
}