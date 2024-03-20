/*
https://leetcode.com/problems/find-the-closest-palindrome/submissions/1209438711/

Time: O(N)
Space: O(N)
*/
public class Solution {
    public string NearestPalindromic(string n) {
        long num = long.Parse(n);
        int size = n.Length;
        if(num==0) return "1";

        bool isEvenLength = size % 2 == 0;
        long firstHalf = long.Parse(n.Substring(0, size / 2 + (isEvenLength ? 0 : 1)));
        List<long> candidates = new(){
            GenerateCandidate(firstHalf, isEvenLength),
            GenerateCandidate(firstHalf+1, isEvenLength),
            GenerateCandidate(firstHalf-1, isEvenLength),
            GenerateCandidate(firstHalf, isEvenLength),
            (long)Math.Pow(10, size - 1) - 1,
            (long)Math.Pow(10, size) + 1
        };

        long closest = long.MaxValue, minDiff = long.MaxValue;
        foreach(long candidate in candidates){
            long diff = Math.Abs(num-candidate);
            if(diff==0) continue;
            if(diff<minDiff || (diff == minDiff && candidate < closest)){
                closest = candidate;
                minDiff = diff;
            }
        }

        return closest.ToString();
    }

    private long GenerateCandidate(long half, bool isEvenLength){
        char[] arr = half.ToString().ToCharArray();
        int len = arr.Length;
        string firstPart = new string(arr);
        string secondPart = new string(arr.Take(len - (isEvenLength ? 0 : 1)).Reverse().ToArray());
        return long.Parse(firstPart + secondPart);
    }
}