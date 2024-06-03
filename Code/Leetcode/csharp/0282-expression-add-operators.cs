/*
https://leetcode.com/problems/expression-add-operators/submissions/1275887533/

https://leetcode.com/problems/expression-add-operators/submissions/1275882727/

Time: O(4^n)
SpacE: O(n)
*/

public class Solution {
    public IList<string> AddOperators(string num, int target) {
        List<string> res = new();
        StringBuilder sb = new();
        
        Dfs(res, sb, num, 0, target, 0, 0);
        
        return res;
    }
    
    private void Dfs(List<string> res, StringBuilder sb, string num, int pos, int target, long prev, long multi){
        if(pos == num.Length){
            if(target == prev){ res. Add(sb.ToString()); return;}
        }
        
        for(int i=pos;i<num.Length;i++){
            if(num[pos] == '0' && pos != i){
                break;
            }
            long curr = long.Parse(num.Substring(pos, i - pos + 1));
            int len = sb.Length;
            if(pos == 0){
                Dfs(res, sb.Append(curr), num, i + 1, target, curr, curr);
                sb.Length = len;
            }
            else{
                Dfs(res, sb.Append("+").Append(curr), num, i + 1, target, prev + curr, curr);
                sb.Length = len;
                Dfs(res, sb.Append("-").Append(curr), num, i + 1, target, prev - curr, -curr);
                sb.Length = len;
                Dfs(res, sb.Append("*").Append(curr), num, i + 1, target, prev - multi + multi * curr, multi * curr);
                sb.Length = len;
            }
        }
    }
}

public class Solution {
     public IList<string> AddOperators(string num, int target) {
        var result = new List<string>();
        Backtracking(result, new StringBuilder(), num, target, 0, 0, null);
        return result;
    }

    private void Backtracking(List<string> result, StringBuilder path, string num, int target, int index, long value, long? prev) {
        // If we have reached the end of the string and the current value equals the target, add the path to result
        if (index == num.Length && value == target) {
            result.Add(path.ToString());
            return;
        }

        // Iterate through the string to form numbers and apply operations
        for (int i = index + 1; i <= num.Length; i++) {
            string str = num.Substring(index, i - index);
            // Check for leading zeros
            if (i == index + 1 || (i > index + 1 && num[index] != '0')) {
                long tmp = long.Parse(str);
                int len = path.Length;
                
                // If this is the first number, initialize the path
                if (prev == null) {
                    path.Append(str);
                    Backtracking(result, path, num, target, i, tmp, tmp);
                    path.Length = len;
                } else {
                    // Add the current number with a '+' operator
                    path.Append("+").Append(str);
                    Backtracking(result, path, num, target, i, value + tmp, tmp);
                    path.Length = len;

                    // Subtract the current number with a '-' operator
                    path.Append("-").Append(str);
                    Backtracking(result, path, num, target, i, value - tmp, -tmp);
                    path.Length = len;

                    // Multiply the current number with a '*' operator
                    path.Append("*").Append(str);
                    Backtracking(result, path, num, target, i, value - prev.Value + prev.Value * tmp, prev.Value * tmp);
                    path.Length = len;
                }
            }
        }
    }
}