/*
https://leetcode.com/problems/maximize-happiness-of-selected-children/submissions/1255444573/

Time: O(nlogk)
Space: O(k)
*/

public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {
        long happyKids = 0;
        PriorityQueue<int, int> kids = new();
        for(int i=0;i<happiness.Length;i++){
            kids.Enqueue(happiness[i], happiness[i]);
            if(kids.Count > k){
                kids.Dequeue();
            }
        }
        while(kids.Count > 0){
            k--;
            long currHappiness = kids.Dequeue() - k;
            if(currHappiness <= 0){ 
                continue;
            }  
            happyKids += currHappiness;  
            
        }
        return happyKids;
    }
}