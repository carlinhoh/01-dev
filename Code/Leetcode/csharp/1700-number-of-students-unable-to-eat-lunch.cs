/*
https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/submissions/1461994278/

Time: O(n)
Space: O(1)
*/
public class Solution {
    public int CountStudents(int[] students, int[] sandwiches) {
        Dictionary<int, int> preferences = new();
        for(int i=0;i<students.Length;i++){
            preferences.TryAdd(students[i], 0);
            preferences[students[i]]++;
        }
        int result = students.Length;
        foreach(var sand in sandwiches){
            if(preferences.ContainsKey(sand) && preferences[sand] > 0){
                result--;
                preferences[sand]--;
            }
            else 
                return result;
        }

        return result;
    }
}