/*
https://leetcode.com/problems/sentence-similarity-ii/submissions/1211300867/

Time: O((n+k)*m), where n is the number of words in sentence1 and sentence2, k is the number of similar pairs and m be the average length of words in sentence1, sentence2.
Space: O(k*m)
*/
public class Solution {
    public bool AreSentencesSimilarTwo(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs) {
        if (sentence1.Length != sentence2.Length) return false;
        
        UnionFindString similarSentences = new UnionFindString(20);

        foreach(var pair in similarPairs){
            similarSentences.Union(pair[0], pair[1]);
        }

        for(int i=0;i<sentence1.Length;i++){
            var word1 = sentence1[i];
            var word2 = sentence2[i];
            if(word1!=word2 && similarSentences.Connected(word1,word2)== false){
                return false;
            }
        }
        return true;
    }

    public class UnionFindString{
        private Dictionary<string, int> stringToIndex;
        private int[] root;
        private int[] rank;
        private int index;

        public UnionFindString(int size){
            stringToIndex = new Dictionary<string, int>();
            root = new int[size];
            rank = new int[size];
            index = 0;

            for(int i=0;i<size;i++){
                root[i] = i;
                rank[i] = 1;
            }
        }
         private void EnsureCapacity() {
            if (index >= root.Length) {
            int newSize = root.Length * 2;
            int[] newRoot = new int[newSize];
            int[] newRank = new int[newSize];
            root.CopyTo(newRoot, 0);
            rank.CopyTo(newRank, 0);
            root = newRoot;
            rank = newRank;
            }
        }
        private int Find(int x){
            if(x==root[x]){
                return x;
            }
            return root[x] = Find(root[x]);
        }

        private int Find(string str){
            if (!stringToIndex.ContainsKey(str)) {  
                EnsureCapacity();              
                stringToIndex[str] = index;
                root[index] = index;
                rank[index] = 1;
                index++;
            }
            return Find(stringToIndex[str]);
        }

        public void Union(string str1, string str2){
            int rootStr1 = Find(str1);
            int rootStr2 = Find(str2);

            if(rootStr1 != rootStr2){
                if (rank[rootStr1] > rank[rootStr2]) {
                    root[rootStr2] = rootStr1;
                } else if (rank[rootStr1] < rank[rootStr2]) {
                    root[rootStr1] = rootStr2;
                } else {
                    root[rootStr2] = rootStr1;
                    rank[rootStr1]++;
                }
            }
        }

        public bool Connected(string str1, string str2) {
            return Find(str1) == Find(str2);
        }
    }
}