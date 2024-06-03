/*
https://leetcode.com/problems/dot-product-of-two-sparse-vectors/submissions/1275868690/

Time: O(n)
Space: O(L), where L is the number of nonzero elements

https://leetcode.com/problems/dot-product-of-two-sparse-vectors/submissions/667951136/

Time: O(n)
Space: O(1)
*/

public class SparseVector {
    List<(int index, int num)> values;
    
    public SparseVector(int[] nums) {
        values = new();
        for(int i=0;i<nums.Length;i++){
            if(nums[i] != 0){
                values.Add((i, nums[i]));
            }
        }
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) {
        int n = values.Count;
        int m = vec.values.Count;
        
        int p1 = 0;
        int p2 = 0;
        
        int result = 0;
        
        while(p1 < n && p2 < m){
            if(values[p1].index == vec.values[p2].index){
                result += values[p1].num * vec.values[p2].num;
                p1++;
                p2++;
            }
            else if(values[p1].index > vec.values[p2].index){
                p2++;
            }
            else{
                p1++;
            }
        }
        
        return result;
    }
}

public class SparseVector {
    private List<int[]> pairs;

    public SparseVector(int[] nums) {
        pairs = new List<int[]>();
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                pairs.Add(new int[] { i, nums[i] });
            }
        }
    }

    // Return the dot product of two sparse vectors
    public int DotProduct(SparseVector vec) {
        int result = 0, p = 0, q = 0;
        while (p < pairs.Count && q < vec.pairs.Count) {
            if (pairs[p][0] == vec.pairs[q][0]) {
                result += pairs[p][1] * vec.pairs[q][1];
                p++;
                q++;
            } else if (pairs[p][0] > vec.pairs[q][0]) {
                q++;
            } else {
                p++;
            }
        }
        return result;
    }
}

public class SparseVector {
    
    int[] localNums = new int[] { };
    
    public SparseVector(int[] nums) {
        localNums = nums;        
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) {
        int[] v2 = vec.localNums;
        int n = v2.Length;
        
        int result = 0;
        for(int i=0;i<n;i++){
            result+= localNums[i] * v2[i];
        }
        return result;
    }
}
