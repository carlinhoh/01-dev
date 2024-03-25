/*
https://leetcode.com/problems/reconstruct-itinerary/submissions/1213624899/

Time: O(NlogN)
Space: O(N)
*/
public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        Dictionary<string, List<string>> graph = new();
        foreach(var ticket in tickets){
            graph.TryAdd(ticket[0], new List<string>());
            graph[ticket[0]].Add(ticket[1]);
        }

        foreach(var destinations in graph.Values){
            destinations.Sort((a,b) => a.CompareTo(b));
        }
        var itinerary = new List<string>();
        void DFS(string airport){
            while(graph.ContainsKey(airport) && graph[airport].Count > 0){
                var next = graph[airport][0];
                graph[airport].RemoveAt(0);
                DFS(next);
            }
            itinerary.Add(airport);
        }

        DFS("JFK");

        itinerary.Reverse();
        return itinerary;
    }

    
}