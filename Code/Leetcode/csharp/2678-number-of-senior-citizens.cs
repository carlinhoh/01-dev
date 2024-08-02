/*
https://leetcode.com/problems/number-of-senior-citizens/submissions/1341348373/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int CountSeniors(string[] details) {
        int senior = 0;
        foreach(var detail in details){
            int firstNumber = detail[11] - '0';
            int secondNumber = detail[12] - '0';

            int age = firstNumber * 10 + secondNumber;

            if(age > 60){
                senior++;
            }
        }
        return senior;
    }
}