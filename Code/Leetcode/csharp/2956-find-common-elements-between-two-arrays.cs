/*
freq counter https://leetcode.com/problems/find-common-elements-between-two-arrays/submissions/1266146689/

Time: O(1)
Space: O(1)

2 hashs https://leetcode.com/problems/find-common-elements-between-two-arrays/submissions/1266093324/

Time: O(1)
Space: O(1)
*/
public class Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        int[] freq1 = new int[101], freq2 = new int[101];
        foreach(var num in nums1){
            freq1[num]++;
        }
        foreach(var num in nums2){
            freq2[num]++;
        }

        int count1 = 0, count2=0;
        for(int i=0;i<101;i++){
            if(freq2[i] > 0){
                count1 += freq1[i];
            }
            if(freq1[i] > 0){
                count2 += freq2[i];
            }
        }
        return new int[2]{count1, count2};
    }
}
public class Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        HashSet<int> setNums1 = new HashSet<int>(nums1);
        HashSet<int> setNums2 = new HashSet<int>(nums2);
        
        int countInNums1 = 0;
        for (int i = 0; i < nums1.Length; i++)
        {
            if (setNums2.Contains(nums1[i]))
            {
                countInNums1++;
            }
        }

        int countInNums2 = 0;
        for (int i = 0; i < nums2.Length; i++)
        {
            if (setNums1.Contains(nums2[i]))
            {
                countInNums2++;
            }
        }

        int[] answer = new int[] { countInNums1, countInNums2 };
        
        return answer;
    }
}