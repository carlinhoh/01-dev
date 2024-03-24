/*
https://leetcode.com/problems/lru-cache/submissions/1212241521/
Time: O(1)
Space: O(capacity)
*/

public class LRUCache {
    
   public class Node{
        public int Key;
        public int Value;
        public Node Previous;
        public Node Next;
        
       public Node(int key, int value){
            Key  = key;
            Value = value;
        }
    }    
    
    Node head = new Node(0,0);
    Node tail = new Node(0,0);
    
    Dictionary<int,Node> cache = new Dictionary<int,Node>();
    
    int cache_capacity = 0;
    
    public LRUCache(int capacity) {
        cache_capacity = capacity;
        head.Next = tail;
        tail.Previous = head;
    }
    
    public int Get(int key) {
        if(cache.ContainsKey(key)){
            Node newNode = cache[key];
            Remove(newNode);
            Add(newNode);
            return newNode.Value;        
        }
        return -1;
    }
    
    public void Put(int key, int value) { 
        if(cache.ContainsKey(key)){
            Remove(cache[key]);
        }
        if(cache.Count==cache_capacity){
            Remove(tail.Previous);
        }        
        Add(new Node(key,value));
    }
    
   public void Add(Node node){
        cache.Add(node.Key, node);
        Node currentFirst = head.Next;
        head.Next = node;
        node.Previous = head;
        currentFirst.Previous = node;
        node.Next = currentFirst;
        
   }
    
  public void Remove(Node node){
        cache.Remove(node.Key);
        node.Previous.Next = tail;
        node.Previous.Next = node.Next;
        node.Next.Previous = node.Previous;        
   }
}