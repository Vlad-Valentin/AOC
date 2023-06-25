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

        public void WriteSupplierSent(int s, int wStart, int wEnd, List<int> t)
        {
            Console.Write($"\n\nSupplier {s - 1} ({s}): ");
            for (int w = wStart; w <= wEnd; w++)
            {
                if (GetCapacity(w, s) != 0)
                {
                    Console.Write($"{GetCapacity(w, s)} ");
                }
                else if (t != null)
                {
                    foreach (var transit in t)
                    {
                        var arcs = Arcs.Where(a => a.Key.Item1 == transit && a.Key.Item2 == s);

                        foreach (var a in arcs)
                        {
                            if (GetCapacity(w, transit) != 0 && a.Value != 0)
                            {
                                Console.Write($"{GetCapacity(w, transit)} ");
                                continue;
                            }
                            else
                            {
                                Console.Write($"{0} ");
                            }
                        }
                    }
                }
            }
        }

        public void WriteWarehouseReceived(int w, int sStart, int sEnd, List<int> t)
        {
            Console.Write($"\n\nWarehouse {w - (sEnd + t.Count)} ({w}): ");
            for (int s = sStart; s <= sEnd; s++)
            {
                if (GetCapacity(w, s) != 0)
                {
                    Console.Write($"{GetCapacity(w, s)} ");
                }
                else if (t != null)
                {
                    foreach (var transit in t)
                    {
                        var arcs = Arcs.Where(a => a.Key.Item1 == transit && a.Key.Item2 == s);

                        foreach (var a in arcs)
                        {
                            if (GetCapacity(w, transit) != 0 && a.Value != 0)
                            {
                                Console.Write($"{GetCapacity(w, transit)} ");
                                continue;
                            }
                            else
                            {
                                Console.Write($"{0} ");
                            }
                        }
                    }
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
