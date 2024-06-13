/*
https://leetcode.com/problems/minimum-number-of-moves-to-seat-everyone/submissions/1286637624/

Time: O(n + m)
Space: O(m)
*/
public class Solution
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        int maxPosition = Math.Max(FindMax(seats), FindMax(students));
        int[] differences = new int[maxPosition];

        foreach (int position in seats)
        {
            differences[position - 1]++;
        }

        foreach (int position in students)
        {
            differences[position - 1]--;
        }

        int moves = 0;
        int unmatched = 0;
        foreach (int difference in differences)
        {
            moves += Math.Abs(unmatched);
            unmatched += difference;
        }

        return moves;
    }

    private int FindMax(int[] array)
    {
        int maximum = 0;
        foreach (int num in array)
        {
            if (num > maximum)
            {
                maximum = num;
            }
        }
        return maximum;
    }
}
