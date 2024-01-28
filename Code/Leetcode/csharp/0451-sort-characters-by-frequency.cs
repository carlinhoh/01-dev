/*
Time: O(N)
Space: O(N)
*/
public class Solution {
    public string FrequencySort(string s) {
        Dictionary<char, int> freqs = new();
        Dictionary<int, List<char>> buckets = new();

        for(int i=0;i<s.Length; i++){
            freqs.TryAdd(s[i], 0);
            freqs[s[i]]++;
            buckets.TryAdd(i+1, new List<char>());
        }

        StringBuilder sb = new();

        foreach(var freq in freqs){
            int count = freq.Value;
            char c = freq.Key;

            buckets[freq.Value].Add(c);    
        }

        for(int i=s.Length;i>0;i--){
            if(buckets.ContainsKey(i)){
                while(buckets[i].Count != 0){
                    char c = buckets[i].First();
                    buckets[i].Remove(c);
                    sb.Append(c, i);
                }
            }
        }
        return sb.ToString();
    }
}