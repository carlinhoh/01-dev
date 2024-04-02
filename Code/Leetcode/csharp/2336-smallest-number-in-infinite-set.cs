/*
https://leetcode.com/problems/smallest-number-in-infinite-set/submissions/1221535565/

Time: O((m+n) log), where 'n' is the number of AddBack calls and 'm' is the number of popSmallest.
Space: O(n)
*/

public class SmallestInfiniteSet {
    private int small;
    private PriorityQueue<int, int> q;
    private HashSet<int> nums;

    public SmallestInfiniteSet() {
        small = 1;
        q = new PriorityQueue<int, int>();
        nums = new HashSet<int>();
    }
    
    public int PopSmallest() {
        if(q.Count>0 && q.Peek() < small){
            nums.Remove(q.Peek());
            return q.Dequeue();
        }
        return small++;
    }
    
    public void AddBack(int num) {
        if(num < small && !nums.Contains(num)){
            nums.Add(num);
            q.Enqueue(num,num);
        }
    }
}