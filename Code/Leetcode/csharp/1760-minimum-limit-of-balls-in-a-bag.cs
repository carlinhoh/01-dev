public class Solution {
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int left = 1, right = nums.Max();
        while (left < right){
            int mid = left + (right - left) / 2, count = 0;
            foreach (int a in nums){
                count += (a - 1) / mid;
                if(count > maxOperations){
                    break;
                }
            } 
            if (count > maxOperations)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
	}
}