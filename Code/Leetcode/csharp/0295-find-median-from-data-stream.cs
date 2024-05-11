/*
https://leetcode.com/problems/find-median-from-data-stream/submissions/1252943446/

Time: 
    AddNum: O(logn)
    FindMedian: O(1)
Space: 
    O(n)
*/
public class MedianFinder {
    private PriorityQueue<int, int> lower;
    private PriorityQueue<int, int> higher;

    public MedianFinder() {
        lower = new(Comparer<int>.Create((a,b) => b.CompareTo(a)));
        higher = new();

    }
    
    public void AddNum(int num) {
        if(lower.Count == 0 || num < lower.Peek()){
            lower.Enqueue(num, num);
        }
        else{
            higher.Enqueue(num, num);
        }
        if(lower.Count > higher.Count + 1){
            lower.TryDequeue(out int toMove, out int _);
            higher.Enqueue(toMove, toMove);
        }
        else if(higher.Count > lower.Count){
            higher.TryDequeue(out int toMove, out int _);
            lower.Enqueue(toMove, toMove);
        }
    }
    
    public double FindMedian() {
        if(lower.Count > higher.Count){
            return lower.Peek();
        }
        else{
            return (lower.Peek() + higher.Peek())/2.0;
        }
    }
}