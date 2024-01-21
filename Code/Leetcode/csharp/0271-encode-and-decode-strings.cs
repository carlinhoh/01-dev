/*
#blind-75
#neetcode-150
https://leetcode.com/problems/encode-and-decode-strings/submissions/1152945198/

Time: O(N)
Space: O(K), where K == strs.Length
*/

public class Codec {
    public string encode(IList<string> strs) {
        StringBuilder ans = new();
        foreach(var str in strs){
            ans.Append(str.Length.ToString() + "#" + str);
        }
        return ans.ToString();
    }

    public IList<string> decode(string s) {
        List<string> ans = new();
        int i = 0;
        while(i<s.Length){
            int j = i;
            while(s[j]!='#'){
                j++;
            }
            int length = Int32.Parse(s.Substring(i,j-i));
            ans.Add(s.Substring(j+1, length));
            i=j+1+length;
        }
        return ans;
    }
}