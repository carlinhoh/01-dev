/*
Without memory https://leetcode.com/problems/daily-temperatures/submissions/1255456233/

Time: O(n)
Space: O(1)

Stack solution https://leetcode.com/problems/daily-temperatures/submissions/1208558231/
Time: O(n)
Space: O(n)
*/

public class Solution {
    public int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length;
        int hottestDay = 0;
        int[] result = new int[n];


        for(int i=n-1;i>=0;i--){
            int currWeather = temperatures[i];

            if(currWeather >= hottestDay){
                hottestDay = currWeather;
                continue;
            }

            int waitingDays = 1;

            while(temperatures[i + waitingDays] <= currWeather){
                waitingDays += result[i + waitingDays];
            }
            result[i] = waitingDays;
        }

        return result;
    }
}

public class Solution {
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] ans = new int[temperatures.Length];

        Stack<int> weather = new();

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (weather.Count > 0 && temperatures[i] > temperatures[weather.Peek()])
            {
                int index = weather.Pop();
                ans[index] = i - index;
            }
            weather.Push(i);
        }

        return ans;
    }
}
