/*
https://leetcode.com/problems/word-search-ii/submissions/1211958334/

Time: O(M*N*4^L)
Space: O(M+N)
*/

public class Solution {
    HashSet<string> paths = new();
    public HashSet<string> invalidPrefixes = new HashSet<string>();
    public IList<string> FindWords(char[][] board, string[] words) {
        if(words.Length==0){
            return default;
        }
        Trie wordsPath = new();
        foreach(var word in words){
            wordsPath.Insert(word);
        }
        int n = board.Length;
        int m = board[0].Length;
        for(int row = 0; row<n; row++){
            for(int col = 0; col<m;col++){
                var currentChar = board[row][col];
                if(wordsPath.StartsWith(currentChar.ToString())){
                    StringBuilder sb = new();
                    Dfs(board, wordsPath, row, col, sb);
                }
            }
        } 
        return paths.ToList();
    }

    public void Dfs(char[][] board, Trie wordsPath, int row, int col, StringBuilder sb){
        if(row<0 || col<0 || row>=board.Length || col>=board[0].Length || board[row][col] == '#'){
            return;
        }
        var currentChar = board[row][col];
        
        sb.Append(currentChar.ToString());
        var currentString = sb.ToString();

        if(invalidPrefixes.Contains(currentString)){
            sb.Remove(sb.Length - 1, 1);
            return;
        }

        board[row][col] = '#';

        var isPresent = wordsPath.isTailOrPresent(currentString);

        if(isPresent>=0){
            if(isPresent==1){
                paths.Add(currentString);
            }
            Dfs(board, wordsPath, row+1, col, sb);
            Dfs(board, wordsPath, row-1, col, sb);
            Dfs(board, wordsPath, row, col+1, sb);
            Dfs(board, wordsPath, row, col-1, sb);
        }
        else if(isPresent==-1){
            invalidPrefixes.Add(currentString);
        }
        sb.Remove(sb.Length - 1, 1);
        board[row][col] = currentChar;
    }



    public class Trie{
        class TrieNode{
            public TrieNode[] nodes = new TrieNode[26];
            internal TrieNode this[char c]{ get => nodes[c-'a']; set => nodes[c-'a'] = value;}
            public bool Tail { get;set;} = false;
        }

        private TrieNode head;

        public Trie(){
            head = new TrieNode();
        }

        public void Insert(string word){
            var current = head;
            foreach(char c in word){
                if(current[c]==null){
                    current[c] = new TrieNode();
                }
                current = current[c];
            }
            current.Tail = true;
        }

        public bool Search(string word){
            var node = ToTail(word);
            return node != null ? node.Tail : false;
        }
        
        public int isTailOrPresent(string prefix){
            var node = ToTail(prefix);
            if(node == null){
                return -1;
            }
            else if(node.Tail){
                return 1;
            }
            else{
                return 0;
            }
        }
        public bool StartsWith(string prefix){
            return ToTail(prefix) != null;
        }

        private TrieNode ToTail(string prefix){
            var current = head;
            foreach(char c in prefix){
                if(current[c]==null){
                    return null;
                }
                current = current[c];
            }
            return current;
        }

        public bool IsTail(string prefix){
            var current = head;
            foreach(char c in prefix){
                if(current[c]==null){
                    return false;
                }
                current = current[c];
            }
            return current.Tail;
        }
    }
}