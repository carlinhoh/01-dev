/*
https://leetcode.com/problems/bus-routes/submissions/1209234726/

Time: O(N²*K), N is the size of routes and K is the size of routes[i]
Space: O(M*K)
*/

public class Solution
{
    public int NumBusesToDestination(int[][] routes, int source, int target)
    {
        if (target == source)
        {
            return 0;
        }
        Dictionary<int, HashSet<int>> busStops = new();

        for (int bus = 0; bus < routes.Length; bus++)
        {

            foreach (var stop in routes[bus])
            {

                if (!busStops.ContainsKey(stop))
                {
                    busStops.Add(stop, new HashSet<int>());
                }
                busStops[stop].Add(bus);
            }
        }

        return leastNumberOfBuses(routes, busStops, source, target);
    }

    private int leastNumberOfBuses(int[][] routes, Dictionary<int, HashSet<int>> busStops, int source, int target)
    {
        var visitedBuses = new HashSet<int>();
        var visitedStops = new HashSet<int> { source };
        var queue = new Queue<int>();
        int swaps = 0;
        queue.Enqueue(source);
        while (queue.Count > 0)
        {
            swaps++;
            int level = queue.Count;
            for (int i = 0; i < level; i++)
            {
                var currentStop = queue.Dequeue();
                foreach (int bus in busStops.GetValueOrDefault(currentStop, new HashSet<int>()))//Check if exists the current stop in busStops
                {
                    if (visitedBuses.Contains(bus)) continue;

                    visitedBuses.Add(bus);

                    foreach (int stop in routes[bus])
                    {
                        if (visitedStops.Contains(stop)) continue;
                        if (stop == target)
                        {
                            return swaps;
                        }
                        visitedStops.Add(stop);
                        queue.Enqueue(stop);
                    }
                }
            }
        }
        return -1;
    }
}

/*
1: {0}
2: {0}
7: {0, 1}
3: {1}
6: {1}
--

7:  {0}
12: {0,4}
4:  {1}
5:  {1}
15: {1,3}
6:  {2}
19: {3}
9:  {4}
13: {4}
*/