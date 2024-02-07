/*
https://leetcode.com/problems/top-k-frequent-words/submissions/1159397945/
Time:NlogN?
Space: N
*/
public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        
        Dictionary<string, int> freqs = new();
        List<List<string>> buckets = new();
        foreach(var word in words){
            freqs.TryAdd(word, 0);
            freqs[word]++;
            buckets.Add(new List<string>());
        }
        
        int count = 0;

        foreach(var freq in freqs){
            if(buckets[freq.Value].Count > 0){

            }
            buckets[freq.Value].Add(freq.Key);
        }

        List<string> res = new();

        for(int i=buckets.Count-1;i>=0;i--){
            if(buckets[i].Count>0){
                buckets[i].Sort();
                foreach(var elem in buckets[i]){
                    res.Add(elem);
                    if(res.Count == k ){
                        return res;
                    }
                }
            }
        }
        return res;
    }
}