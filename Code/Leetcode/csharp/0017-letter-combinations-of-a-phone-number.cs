/*
https://leetcode.com/problems/letter-combinations-of-a-phone-number/submissions/1266916917/

Time: O(4^n * n) where n is the length of digits
Space: O(n)

https://leetcode.com/problems/letter-combinations-of-a-phone-number/submissions/1266921216/

Time: O(4^n * n) where n is the length of digits
Space: O(n)
*/

public class Solution {
    Dictionary<char, List<char>> telephone = new Dictionary<char, List<char>>(){
        { '2', new List<char> { 'a', 'b', 'c' } },
        { '3', new List<char> { 'd', 'e', 'f' } },
        { '4', new List<char> { 'g', 'h', 'i' } },
        { '5', new List<char> { 'j', 'k', 'l' } },
        { '6', new List<char> { 'm', 'n', 'o' } },
        { '7', new List<char> { 'p', 'q', 'r', 's' } },
        { '8', new List<char> { 't', 'u', 'v' } },
        { '9', new List<char> { 'w', 'x', 'y', 'z' } },
    };
    List<string> res = new();

    public IList<string> LetterCombinations(string digits) {
        if(digits.Length == 0){
            return res;
        }
        GetCombinations(digits, 0, "");
        return res;
    }
    private void GetCombinations(string digits, int idx, string currState){
        if(currState.Length == digits.Length){
            res.Add(currState);
            return;
        }
        char digit = digits[idx];
        List<char> letters = telephone[digit];
        foreach(var letter in letters){
            GetCombinations(digits, idx + 1, currState + letter);
        }
    }
}
public class Solution {
    private List<string> combinations = new List<string>();
    private Dictionary<char, string> letters = new Dictionary<char, string> {
        { '2', "abc" }, { '3', "def" },  { '4', "ghi" }, { '5', "jkl" },
        { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" }
    };
    private string phoneDigits;
    public IList<string> LetterCombinations(string digits) {
        if (digits.Length == 0) {
            return combinations;
        }
        phoneDigits = digits;
        Backtrack(0, new StringBuilder());
        return combinations;
    }
    private void Backtrack(int index, StringBuilder path) {
        if (path.Length == phoneDigits.Length) {
            combinations.Add(path.ToString());
            return;
        }
        string possibleLetters = letters[phoneDigits[index]];
        foreach (char letter in possibleLetters) {
            path.Append(letter);
            Backtrack(index + 1, path);
            path.Remove(path.Length - 1, 1);
        }
    }
}