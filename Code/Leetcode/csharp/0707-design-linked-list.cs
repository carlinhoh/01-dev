/*
https://leetcode.com/problems/design-linked-list/submissions/1455773429/

Time: O(1)
Space: O(1)
*/
public class Node{
    public int Val;
    public Node Next;
    public Node Prev;
    public Node(int x) { Val = x; }
}
public class MyLinkedList {
    public int Size;
    public Node Head, Tail;

    public MyLinkedList() {
        Size = 0;
        Head = new Node(0);
        Tail = new Node(0);
        Head.Next = Tail;
        Tail.Prev = Head;
    }
    
    public int Get(int index) {
        if(index < 0 || index >= Size){
            return -1;
        }
        var temp = Head;

        Node curr;
        if (index + 1 < Size - index) {
            curr = Head;
            for (int i = 0; i < index + 1; ++i) curr = curr.Next;
        } else {
            curr = Tail;
            for (int i = 0; i < Size - index; ++i) curr = curr.Prev;
        }

        return curr.Val;
    }
    
    public void AddAtHead(int val) {
        Node predecessor = Head, successor = Head.Next;

        ++Size;
        Node newHead = new Node(val);
        newHead.Prev = predecessor;
        newHead.Next = successor;

        predecessor.Next = newHead;
        successor.Prev = newHead;
    }
    
    public void AddAtTail(int val) {
        Node successor = Tail, predecessor = Tail.Prev;

        ++Size;
        Node newTail = new Node(val);
        newTail.Prev = predecessor;
        newTail.Next = successor;

        predecessor.Next = newTail;
        successor.Prev = newTail;
    }
    
    public void AddAtIndex(int index, int val) {
        if(index > Size) return;
        if (index < 0){
            AddAtHead(val);
            return;
        } 

        Node pred, succ;
        if (index < Size - index) {
            pred = Head;
            for (int i = 0; i < index; ++i) pred = pred.Next;
            succ = pred.Next;
        } else {
            succ = Tail;
            for (int i = 0; i < Size - index; ++i) succ = succ.Prev;
            pred = succ.Prev;
        }

        ++Size;
        Node toAdd = new Node(val);
        toAdd.Prev = pred;
        toAdd.Next = succ;
        pred.Next = toAdd;
        succ.Prev = toAdd;
    }
    
    public void DeleteAtIndex(int index) {
        if (index < 0 || index >= Size) return;

        Node pred, succ;
        if (index < Size - index) {
            pred = Head;
            for (int i = 0; i < index; ++i) pred = pred.Next;
            succ = pred.Next.Next;
        } else {
            succ = Tail;
            for (int i = 0; i < Size - index - 1; ++i) succ = succ.Prev;
            pred = succ.Prev.Prev;
        }

        --Size;
        pred.Next = succ;
        succ.Prev = pred;
    }
}
