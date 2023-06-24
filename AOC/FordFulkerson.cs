namespace AOC
{
    public class FordFulkerson
    {
        #region Properties & Constructors
        public Graph Graph { get; set; }

        private List<int> Predecessors { get; set; }

        private List<int> CurrentNodes { get; set; }

        private int MaxFlow { get; set; }

        public FordFulkerson(Graph graph)
        {
            this.Graph = graph;

            Predecessors = new(Enumerable.Repeat(0, graph.Nodes.Count));

            CurrentNodes = new();

            MaxFlow = 0;
        }
        #endregion

        #region Functions
        public void Write()
        {
            Console.Write("\n\nP: ");
            Predecessors.ForEach(p => { Console.Write($"{p} "); });

            Graph.Write();
        }

        public List<int>? GetAugmentingPath(int s, int t)
        {
            Queue<int> queue = new();
            List<int> predecessors = new(Enumerable.Repeat(0, Graph.Nodes.Count));

            queue.Enqueue(s);
            predecessors[s - 1] = -1;

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                var neighbors = Graph.GetNeighbors(currentNode);

                foreach (var n in neighbors)
                {
                    if (predecessors[n - 1] == 0 && Graph.GetCapacity(currentNode, n) > 0)
                    {
                        queue.Enqueue(n);
                        predecessors[n - 1] = currentNode;

                        if (n == t)
                        {
                            List<int> augmentingPath = new();

                            int node = t;
                            while (node > 0)
                            {
                                augmentingPath.Add(node);
                                node = predecessors[node - 1];
                            }

                            augmentingPath.Reverse();
                            return augmentingPath;
                        }
                    }
                }
            }

            return null;
        }

        public void AugmentPath(List<int> path, int minCapacity)
        {
            for (int i = 0; i < path.Count - 1; ++i)
            {
                int u = path[i];
                int v = path[i + 1];

                Graph.UpdateArc(u, v, -minCapacity);

                Graph.UpdateArc(v, u, minCapacity);
            }
        }

        public int GetMinCapacity(List<int> path)
        {
            int minCapacity = int.MaxValue;

            for (int i = 0; i < path.Count - 1; ++i)
            {
                int to = path[i];
                int from = path[i + 1];
                int capacity = Graph.GetCapacity(to, from);

                minCapacity = Math.Min(minCapacity, capacity);
            }

            return minCapacity;
        }

        public void Apply()
        {
            do
            {
                Predecessors = new(Enumerable.Repeat(0, Graph.Nodes.Count));

                Predecessors[0] = Predecessors.Count;
                CurrentNodes.Add(Graph.Nodes.First());

                while (CurrentNodes.Count > 0 && Predecessors.Last() == 0)
                {
                    Console.Write("\n\nV: ");
                    CurrentNodes.ForEach(c => { Console.Write($"{c} "); });

                    int node = CurrentNodes.First();
                    CurrentNodes.Remove(node);

                    foreach (KeyValuePair<Tuple<int, int>, int> arc in Graph.Arcs)
                    {
                        if (Predecessors[arc.Key.Item2 - 1] == 0)
                        {
                            Predecessors[arc.Key.Item2 - 1] = arc.Key.Item1;
                            CurrentNodes.Remove(arc.Key.Item2);
                        }
                    }
                }

                if (Predecessors.Last() != 0)
                {
                    List<int>? dmf = GetAugmentingPath(Graph.Nodes.First(), Graph.Nodes.Last());

                    if (dmf == null)
                    {
                        Write();
                        Console.WriteLine($"\n\nMax Flow: {MaxFlow}");
                        return;
                    }

                    Console.Write("\n\nDMF: ");
                    dmf.ForEach(d => { Console.Write($"{d} "); });

                    int min = GetMinCapacity(dmf);
                    Console.Write($"\n\nMin Capacity: {min}");

                    MaxFlow += min;

                    AugmentPath(dmf, min);
                }

                Write();
                Console.WriteLine($"\n\nMax Flow: {MaxFlow}");
            }
            while (Predecessors.Last() != 0);
        }
        #endregion
    }
}
