/*
DSU simple https://leetcode.com/problems/accounts-merge/submissions/1261526280/
Time: O(NK * log(NK))
Space: O(NK)

DSU Generic https://leetcode.com/problems/accounts-merge/submissions/1261499924/
Time: O(NK * log(NK))
Space: O(NK)
*/

public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
        DisjointSet<string> mergedAccounts = new();
        Dictionary<string, string> emailToName = new();
        
        foreach (var account in accounts) {
            string name = account[0];
            for (int i = 1; i < account.Count; i++) {
                mergedAccounts.Add(account[i]);
                emailToName[account[i]] = name;
            }
            for (int i = 2; i < account.Count; i++) {
                mergedAccounts.Union(account[i-1], account[i]);
            }
        }

        Dictionary<string, SortedSet<string>> components = new();

        foreach (var email in emailToName.Keys) {
            string root = mergedAccounts.Find(email);
            if (!components.ContainsKey(root)) {
                components[root] = new SortedSet<string>(StringComparer.Ordinal);
            }
            components[root].Add(email);
        }

        List<IList<string>> result = new();
        foreach (var component in components.Values) {
            var currAccount = new List<string> { emailToName[component.Min] };
            currAccount.AddRange(component);
            result.Add(currAccount);
        }

        return result;
    }

    public class DisjointSet<T>
    {
        private readonly Dictionary<T, int> rank;
        private readonly Dictionary<T, T> root;

        public DisjointSet()
        {
            rank = new Dictionary<T, int>();
            root = new Dictionary<T, T>();
        }

        public void Add(T element)
        {
            if (!root.ContainsKey(element))
            {
                rank[element] = 1;
                root[element] = element;
            }
        }

        public void AddRange(List<T> elements)
        {
            foreach(var element in elements){
                if (!root.ContainsKey(element))
                {
                    rank[element] = 1;
                    root[element] = element;
                }
            }
        }

        public T Find(T x)
        {
            if (!root[x].Equals(x))
            {
                root[x] = Find(root[x]);
            }
            return root[x];
        }

        public void Union(T x, T y)
        {
            T rootX = Find(x);
            T rootY = Find(y);

            if (!rootX.Equals(rootY))
            {
                int rankX = rank[rootX];
                int rankY = rank[rootY];

                if (rankX > rankY)
                {
                    root[rootY] = rootX;
                }
                else if (rankX < rankY)
                {
                    root[rootX] = rootY;
                }
                else
                {
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }
            }
        }

        public bool IsConnected(T x, T y)
        {
            return Find(x).Equals(Find(y));
        }

        public List<T> GetConnectedComponent(T element)
        {
            if (!root.ContainsKey(element))
            {
                throw new ArgumentException("Element not found in the disjoint set.");
            }

            T rootElement = Find(element);
            List<T> component = new List<T>();

            foreach (var item in root.Keys)
            {
                if (Find(item).Equals(rootElement))
                {
                    component.Add(item);
                }
            }

            return component;
        }
    }
}
