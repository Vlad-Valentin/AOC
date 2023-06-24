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
            for (int t = 2; t <= 4; t++)
            {
                Console.Write($"{GetCapacity(p, t)} ");
            }
        }

        public void WriteTeamTimes(int t)
        {
            Console.WriteLine($"\nTeam {t - 1} ({t}): ");
            for (int p = 5; p <= 11; p++)
            {
                Console.Write($"{GetCapacity(p, t)} ");
            }
        }

        public void WriteSupplySent(int s, int t)
        {
            Console.WriteLine($"\nSupply {s - 1} ({s}): ");
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

        public void WriteDemandRecevied(int d, int t)
        {
            Console.WriteLine($"\nDemand {d - 4} ({d}): ");
            for (int s = 2; s <= 3; s++)
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
