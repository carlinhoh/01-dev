/*
https://leetcode.com/problems/relative-ranks/submissions/1252702831/

Time: O(n + k), where k = score.Max() - score.Min() + 1
Space: O(k)

*/
public class Solution {
    public string[] FindRelativeRanks(int[] score) {
        int max = int.MinValue;
        int min = int.MaxValue;

        foreach(var num in score){
            max = Math.Max(num, max);
            min = Math.Min(num, min);
        }

        int[] bucket = new int[max - min + 1];

        for(int i=0;i<score.Length;i++){
            bucket[score[i] - min] = i + 1;
        }

        int pos = 0;

        string[] medals = {"Gold Medal", "Silver Medal", "Bronze Medal"};

        string[] result = new string[score.Length];

        for(int i=bucket.Length-1;i>=0;i--){
            if(bucket[i] > 0){
                if(pos < 3){
                    result[bucket[i]-1] = medals[pos];
                }
                else{
                    result[bucket[i]-1] = (pos+1).ToString();
                }
                pos++;
            }
        }

        return result;
    }
}