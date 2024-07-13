/*
https://leetcode.com/problems/robot-collisions/submissions/1320124354/

Time: O(nlogn)
Space: O(n)
*/
public class Solution
{
    public List<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        int n = positions.Length;
        int[] indices = Enumerable.Range(0, n).ToArray();
        List<int> result = new List<int>();
        Stack<int> stack = new Stack<int>();

        Array.Sort(indices, (lhs, rhs) => positions[lhs].CompareTo(positions[rhs]));

        foreach (int currentIndex in indices)
        {
            if (directions[currentIndex] == 'R')
            {
                stack.Push(currentIndex);
            }
            else
            {
                while (stack.Count > 0 && healths[currentIndex] > 0)
                {
                    int topIndex = stack.Pop();

                    if (healths[topIndex] > healths[currentIndex])
                    {
                        healths[topIndex] -= 1;
                        healths[currentIndex] = 0;
                        stack.Push(topIndex);
                    }
                    else if (healths[topIndex] < healths[currentIndex])
                    {
                        healths[currentIndex] -= 1;
                        healths[topIndex] = 0;
                    }
                    else
                    {
                        healths[currentIndex] = 0;
                        healths[topIndex] = 0;
                    }
                }
            }
        }

        for (int index = 0; index < n; ++index)
        {
            if (healths[index] > 0)
            {
                result.Add(healths[index]);
            }
        }

        return result;
    }
}
