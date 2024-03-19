/*
https://leetcode.com/problems/evaluate-reverse-polish-notation/submissions/1208384080/
#neetcode-150
Time:O(N)
Space:O(N)
*/

public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> operands = new();
        foreach(var token in tokens){
            if(int.TryParse(token, out int number)){
                operands.Push(number);
            }
            else{
                operands.Push(EvaluateExpression(operands.Pop(),operands.Pop(),token));
            }
        }
        return operands.Peek();
    }
    
    public int EvaluateExpression(int b, int a, string token){
        return token switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => a / b,
            _ => throw new NotSupportedException()
        };
    }
}