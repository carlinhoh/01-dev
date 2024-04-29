/*
https://leetcode.com/problems/simplify-path/submissions/1245295351/

Time: O(n)
Space: O(k), Where k is the number of valid directories that will be added to the stringbuilder.
*/
public class Solution {
    public string SimplifyPath(string path) {
        Stack<string> stack = new();
        var paths = path.Split("/");

        foreach(var directory in paths){
            if(directory == "." || string.IsNullOrEmpty(directory)){
                continue;
            }
            else if(directory == ".."){
                if(stack.Count > 0){
                    stack.Pop();
                }
            }
            else{
                stack.Push(directory);
            }
        }
        
        var res = "/" + string.Join("/", stack.Reverse());

        return res;
    }
}

public class Solution {
    public string SimplifyPath(string path) {
        
        StringBuilder sb = new();
        
        int jumps = 0;
        var paths = path.Split("/");

        for(int i = paths.Length-1;i>=0;i--){
            var curr = paths[i];
            if(curr == ".."){
                jumps++;
            }
            else if(curr == "." || curr == ""){
                continue;
            }
            else if(jumps > 0){
                jumps--;
            }
            else{
                sb.Insert(0, "/" + paths[i]);
            }
        }

        return sb.Length==0 ? "/" : sb.ToString();
    }
}

