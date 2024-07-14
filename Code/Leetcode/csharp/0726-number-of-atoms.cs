/*
https://leetcode.com/problems/number-of-atoms/submissions/1321216957/

Time: O(n * log(n))
Space: O(K * log(K)), Where k is the number of unique atoms
*/
class Solution {
    public string CountOfAtoms(string formula) {
        var pattern = "([A-Z][a-z]*)(\\d*)|(\\()|(\\))(\\d*)";
        var matches = System.Text.RegularExpressions.Regex.Matches(formula, pattern);
        var list = new System.Collections.Generic.List<string[]>();
        foreach (System.Text.RegularExpressions.Match match in matches) {
            list.Add(new string[] {
                match.Groups[1].Value,
                match.Groups[2].Value,
                match.Groups[3].Value,
                match.Groups[4].Value,
                match.Groups[5].Value,
            });
        }
        list.Reverse();

        var finalMap = new System.Collections.Generic.Dictionary<string, int>();
        var stack = new System.Collections.Generic.Stack<int>();
        stack.Push(1);

        int runningMul = 1;
        foreach (var quintuple in list) {
            var atom = quintuple[0];
            var count = quintuple[1];
            var left = quintuple[2];
            var right = quintuple[3];
            var multiplier = quintuple[4];

            if (!string.IsNullOrEmpty(atom)) {
                int cnt = count.Length > 0 ? int.Parse(count) : 1;
                if (finalMap.ContainsKey(atom)) {
                    finalMap[atom] += cnt * runningMul;
                } else {
                    finalMap[atom] = cnt * runningMul;
                }
            } else if (!string.IsNullOrEmpty(right)) {
                int currMultiplier = multiplier.Length > 0 ? int.Parse(multiplier) : 1;
                runningMul *= currMultiplier;
                stack.Push(currMultiplier);
            } else if (!string.IsNullOrEmpty(left)) {
                runningMul /= stack.Pop();
            }
        }

        var sortedMap = new System.Collections.Generic.SortedDictionary<string, int>(finalMap);
        var ans = new System.Text.StringBuilder();
        foreach (var atom in sortedMap.Keys) {
            ans.Append(atom);
            if (sortedMap[atom] > 1) {
                ans.Append(sortedMap[atom]);
            }
        }

        return ans.ToString();
    }
}
