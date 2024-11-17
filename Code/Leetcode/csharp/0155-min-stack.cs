/*

https://leetcode.com/problems/min-stack/submissions/1159479033/

Time: O(1)
Space: O(N)
*/
public class MinStack {
    Stack<int> stack = new Stack<int>();
    Stack<int> minStack = new Stack<int>();
    
    public MinStack() {
        
    }
    
    public void Push(int val) {
        stack.Push(val);
        
        if(minStack.Count == 0 || minStack.Peek() > val){
            minStack.Push(val);            
        }
        else{
            minStack.Push(minStack.Peek());
        }
    }
    
    public void Pop() {
       stack.Pop();
       minStack.Pop();
    }
    
    public int Top() {
        return stack.Peek();
    }
    
    public int GetMin() {
        return minStack.Peek();
    }
}

public class MinStack {
    Stack<long> stack;
    long min;
    public MinStack() {
        stack = new();
    }
    
    public void Push(int val) {
        if(stack.Count == 0){
            stack.Push(0L);
            min = val;
        }
        else{
            stack.Push(val - min);
            if(val < min){
                min = val;
            }
        }
    }
    
    public void Pop() {
        if (stack.Count == 0) return;
        long pop = stack.Pop();
        if (pop < 0) min -= pop;
    }
    
    public int Top() {
        long top = stack.Peek();
        return top > 0 ? (int)(top + min) : (int)(min);
    }
    
    public int GetMin() {
        return (int)min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */