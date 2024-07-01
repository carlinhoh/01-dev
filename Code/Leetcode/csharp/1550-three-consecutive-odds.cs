/*
https://leetcode.com/problems/three-consecutive-odds/submissions/1306370571/

Time: O(n)
Space: O(1)

https://leetcode.com/problems/three-consecutive-odds/submissions/1306369207/
Time: O(n)
Space: O(1)
*/

public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        int odd = 0;
        for(int i=0;i<arr.Length;i++){
            if(arr[i] % 2 != 0){
                odd++;
            }
            else{
                odd = 0;
            }

            if(odd == 3){
                return true;
            }
        }

        return false;
    }
}
public class Solution {
    public bool ThreeConsecutiveOdds(int[] arr) {
        for(int i=1;i<arr.Length-1;i++){
            if(arr[i-1] % 2 != 0 
            && arr[i] % 2 != 0
            && arr[i+1] % 2 != 0){
                return true;
            }
        }
        return false;
    }
}