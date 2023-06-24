namespace AOC
{
    public class Graph
    {
        #region Properties & Constructors
        public List<int> Nodes { get; set; }

        public Dictionary<Tuple<int, int>, int> Arcs { get; set; }

        public Graph()
        {
            Nodes = new();
            Arcs = new();
        }

        public Graph(List<int> nodes, Dictionary<Tuple<int, int>, int> arcs)
        {
            Nodes = nodes;
            Arcs = arcs;
        }
        #endregion

        #region Functions
        public void Write()
        {
            Console.Write("\nN: ");
            Nodes.ForEach(n => { Console.Write($"{n} "); });

            Console.Write("\nA: ");
            Arcs.Keys.ToList().ForEach(a => { Console.Write($"\n{a} - {Arcs[a]} "); });
        }

        public void WriteProjectTimes(int p)
        {
            Console.WriteLine($"\nProject {p - 4} ({p}): ");
            for (int e = 2; e <= 4; e++)
            {
                Console.Write($"{GetCapacity(e, p)} ");
            }
        }

        public void WriteTeamTimes(int t)
        {
            Console.WriteLine($"\nTeam {t - 1} ({t}): ");
            for (int p = 5; p <= 11; p++)
            {
                Console.Write($"{GetCapacity(t, p)} ");
            }
        }

        public void WriteSupplySent(int s)
        {
            Console.WriteLine($"\nSupply {s - 1} ({s}): ");
            for (int d = 5; d <= 6; d++)
            {
                Console.Write($"{GetCapacity(s, d)} ");
            }
        }

        public void WriteDemandRecevied(int d)
        {
            Console.WriteLine($"\nDemand {d - 4} ({d}): ");
            for (int s = 1; s <= 2; s++)
            {
                Console.Write($"{GetCapacity(s, d)} ");
            }
        }

        public void AddNode(int node)
        {
            if (Nodes.Contains(node)) { return; }

            Nodes.Add(node);
        }

        public void DeleteNode(int node)
        {
            if (!Nodes.Contains(node)) { return; }

            Nodes.Remove(node);
        }

        public void AddArc(int from, int to, int capacity)
        {
            Tuple<int, int> nodes = Tuple.Create(from, to);

            if (Arcs.ContainsKey(nodes))
            {
                Arcs[nodes] = capacity;
                return;
            }

            Arcs.Add(nodes, capacity);
        }

        public void UpdateArc(int from, int to, int capacity)
        {
            Tuple<int, int> nodes = Tuple.Create(from, to);

            if (!Arcs.ContainsKey(nodes))
            {
                Arcs.Add(nodes, capacity);
                return;
            }

            Arcs[nodes] += capacity;
        }

        public void DeleteArc(int from, int to)
        {
            Tuple<int, int> nodes = Tuple.Create(from, to);

            if (Arcs.ContainsKey(nodes))
            {
                Arcs.Remove(nodes);
            }
        }

        public int GetCapacity(int from, int to)
        {
            Tuple<int, int> key = new(from, to);

            if (!Arcs.ContainsKey(key))
            {
                return 0;
            }

            return Arcs[key];
        }

        public List<int> GetNeighbors(int node)
        {
            List<int> neighbors = new();

            foreach (var arc in Arcs)
            {
                int to = arc.Key.Item1;
                int from = arc.Key.Item2;

                if (to == node)
                {
                    neighbors.Add(from);
                    continue;
                }

                if (from == node)
                {
                    neighbors.Add(to);
                    continue;
                }
            }

            return neighbors;
        }
        #endregion
    }
}
