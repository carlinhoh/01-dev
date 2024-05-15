/*
https://leetcode.com/problems/product-of-two-run-length-encoded-arrays/submissions/1258303961/

Time: O(n + m)
Space: O(1), if the variable used to create the answer counts O(n + m)
*/
public class Solution {
    public IList<IList<int>> FindRLEArray(int[][] encoded1, int[][] encoded2) {
        var p1 = 0;
        var p2 = 0;

        var result = new List<IList<int>>();

        while(p1 < encoded1.Length && p2 < encoded2.Length){
            var min = Math.Min(encoded1[p1][1], encoded2[p2][1]);
            var product = encoded1[p1][0] * encoded2[p2][0];
            
            if(result.Count > 0 && result[result.Count-1][0] == product){
                result[result.Count-1][1] += min;
            } else {
                result.Add(new List<int>{product, min});
            }

            encoded1[p1][1] -= min;
            encoded2[p2][1] -= min;

            p1 += encoded1[p1][1] == 0 ? 1 : 0;
            p2 += encoded2[p2][1] == 0 ? 1 : 0;
        }

        return result;
    }
}
