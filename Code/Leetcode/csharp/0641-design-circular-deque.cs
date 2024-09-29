/*
https://leetcode.com/problems/design-circular-deque/submissions/1405496596/

Time: O(1)
Space: O(k)
*/

public class MyCircularDeque {
    Node First;
    Node Last;
    int Count;
    int Size;
    public MyCircularDeque(int k) {
        Size = k;
        Count = 0;
    }
    
    public bool InsertFront(int value) {
       if(IsFull()) return false;
        if(First == null){
            First = new Node(value);
            Last = First;
        }
        else{
            var newFirst = new Node(value, null, First);
            First.Left = newFirst;
            First = newFirst;
        }
        Count++;
        return true;
    }
    
    public bool InsertLast(int value) {
        if(IsFull()) return false;
        if(First == null){
            First = new Node(value);
            Last = First;
        }
        else{
            Last.Right = new Node(value, Last);
            Last = Last.Right;
        }
        Count++;
        return true;
    }
    
    public bool DeleteFront() {
        if(IsEmpty())
            return false;

        if(Count == 1){
            First = null;
            Last = null;
        }
        else{
            First = First.Right;
        }
        Count--;
        return true;
    }
    
    public bool DeleteLast() {
        if(IsEmpty())
            return false;

        if(Count == 1){
            First = null;
            Last = null;
        }
        else{
            Last = Last.Left;
        }
        Count--;
        return true;
    }
    
    public int GetFront() {
        if(IsEmpty())
            return -1;
        return First.Value;
    }
    
    public int GetRear() {
        if(IsEmpty())
            return -1;
        return Last.Value;
    }
    
    public bool IsEmpty() {
        return Count == 0;
    }
    
    public bool IsFull() {
        return Count == Size;
    }
}

public class Node {
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value, Node left = null, Node right = null){
        Value = value;
        Left = left;
        Right = right;
    }
}
