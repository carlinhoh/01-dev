/*
https://leetcode.com/problems/product-of-the-last-k-numbers/submissions/1275648446/

Time: O(1)
Space: O(n)
*/
public class ProductOfNumbers {
    List<int> prefixProducts;
    
    public ProductOfNumbers() {
        prefixProducts = new List<int>();
        prefixProducts.Add(1); 
    }
    
    public void Add(int num) {
        if (num == 0) {
            prefixProducts = new List<int>();
            prefixProducts.Add(1); 
        } else {
            prefixProducts.Add(prefixProducts[prefixProducts.Count - 1] * num);
        }
    }
    
    public int GetProduct(int k) {
        int n = prefixProducts.Count;
        if (k >= n) return 0;
        return prefixProducts[n - 1] / prefixProducts[n - 1 - k];
    }
}