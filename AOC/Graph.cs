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
            Console.Write("\n\nN: ");
            Nodes.ForEach(n => { Console.Write($"{n} "); });

            Console.Write("\n\nA: ");
            Arcs.Keys.ToList().ForEach(a => { Console.Write($"\nr{a} = {Arcs[a]} "); });
        }

        public void WriteProjectTimes(int p, int tStart, int tEnd)
        {
            Console.Write($"\n\nProject {p - tEnd} ({p}): ");
            for (int t = tStart; t <= tEnd; t++)
            {
                Console.Write($"{GetCapacity(p, t)} ");
            }
        }

        public void WriteTeamTimes(int t, int pStart, int pEnd)
        {
            Console.Write($"\n\nTeam {t - 1} ({t}): ");
            for (int p = pStart; p <= pEnd; p++)
            {
                Console.Write($"{GetCapacity(p, t)} ");
            }
        }

        public void WriteSupplierSent(int s, int t)
        {
            Console.Write($"\n\nWarehouse {s - 1} ({s}): ");
            for (int d = 5; d <= 6; d++)
            {
                if (GetCapacity(d, s) != 0)
                {
                    Console.Write($"{GetCapacity(d, s)} ");
                }
                else
                {
                    Console.Write($"{GetCapacity(d, t)} ");
                }

            }
        }

        public void WriteWarehouseReceived(int w, int t)
        {
            Console.Write($"\n\nDeposit {w - 4} ({w}): ");
            for (int s = 2; s <= 3; s++)
            {
                if (GetCapacity(w, s) != 0)
                {
                    Console.Write($"{GetCapacity(w, s)} ");
                }
                else
                {
                    Console.Write($"{GetCapacity(w, t)} ");
                }
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
