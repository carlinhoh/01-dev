/*
https://leetcode.com/problems/implement-stack-using-queues/submissions/1461999294/

Time: O(n), Push operation
Space: O(1)
*/

public class MyStack {
    Queue<int> q;
    public MyStack() {
        q = new();
    }
    
    public void Push(int x) {
        q.Enqueue(x);
        int size = q.Count;
        while(size > 1){
            q.Enqueue(q.Dequeue());
            size--;
        }
    }
    public int Pop() => q.Dequeue();
    public int Top() => q.Peek();
    public bool Empty() => q.Count == 0;
    
}
