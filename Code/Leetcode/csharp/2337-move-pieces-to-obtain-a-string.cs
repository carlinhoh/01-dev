/*
Stack
https://leetcode.com/problems/move-pieces-to-obtain-a-string/submissions/1471457385

Time: O(n)
Space: O(n), for some cases O(1)

Two Pointers
https://leetcode.com/problems/move-pieces-to-obtain-a-string/submissions/1471468152

Time: O(n)
Space: O(1)
*/
public class Solution {
    public bool CanChange(string start, string target) {
        if(start.Length != target.Length)
            return false;
        Stack<char> stack = new();

        for(int i=0;i<start.Length;i++){
            if(target[i] == 'L'){
                if(stack.Count > 0 && stack.Peek() != 'L'){
                    return false;
                }
                stack.Push(target[i]);
            }
                

            if(start[i]=='L'){
                if(stack.Count == 0 || stack.Peek() != 'L'){
                    return false;
                }
                else{
                    stack.Pop();
                }
            }
                
            
            if(start[i] == 'R'){
                stack.Push(start[i]);
            }
                
            
            if(target[i] == 'R'){
                if(stack.Count == 0 || stack.Peek() != 'R'){
                    return false;
                }
                else{
                    stack.Pop();
                }
            }
        }

        return stack.Count == 0;
    }
}

public class Solution {
    public bool CanChange(string start, string target) {
        int n = start.Length;
        int p1 = 0;
        int p2 = 0;

        while(p1 < n || p2 < n){
            while(p1 < start.Length && start[p1] == '_'){
                p1++;
            }
            while(p2 < start.Length && target[p2] == '_'){
                p2++;
            }

            if (p1 == n || p2 == n){
                return p1 == n && p2 == n;
            }

            if (start[p1] != target[p2]      || 
               (start[p1] == 'L' && p1 < p2) || 
               (start[p1] == 'R' && p1 > p2)) 
                return false;
            
            p1++;
            p2++;
        }

        return true;
    }
}