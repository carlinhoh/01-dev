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

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */