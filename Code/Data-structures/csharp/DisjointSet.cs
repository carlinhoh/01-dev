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
        foreach (var element in elements)
        {
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