/*
https://leetcode.com/problems/basic-calculator-ii/submissions/1244475197/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int Calculate(string s) {
        if(string.IsNullOrEmpty(s)) return 0;

        int length = s.Length;
        int currentNumber = 0;
        int lastNumber = 0;
        int result = 0;
        char operation = '+';

        for(int i=0;i<length;i++){
            var c = s[i];

            if(char.IsDigit(c)){
                currentNumber = currentNumber * 10 + (c - '0');
            }
            if(!char.IsDigit(c) && !char.IsWhiteSpace(c) || i == length-1){
               if (operation == '+') {
                    result += lastNumber;
                    lastNumber = currentNumber;
                } else if (operation == '-') {
                    result += lastNumber;
                    lastNumber = -currentNumber;
                } else if (operation == '*') {
                    lastNumber *= currentNumber;
                } else if (operation == '/') {
                    lastNumber /= currentNumber;
                }
                operation = c;
                currentNumber = 0;
            }
        }
        result += lastNumber;

        return result;
    }
}