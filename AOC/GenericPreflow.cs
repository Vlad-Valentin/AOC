namespace AOC
{
    using System.Collections.Generic;

    namespace AOC
    {
        public class GenericPreflow
        {
            #region Properties
            public Graph Graph { get; set; }
            private Dictionary<int, int> Distances { get; set; }

            private Dictionary<int, int> ExcessFlows { get; set; }

            private int Source { get; set; }
            private int Sink { get; set; }

            #endregion

            #region Constructors
            public GenericPreflow(Graph graph)
            {
                Graph = graph;
                Distances = new();
                ExcessFlows = new Dictionary<int, int>();

                Source = graph.Nodes.ToList().First();
                Sink = graph.Nodes.ToList().Last();
            }
            #endregion

            #region Functions
            public void Apply()
            {
                ExcessFlows = CalculateExcessFlows();

                Distances = CalculateDistances();

                while (SelectActiveNode() != -1)
                {
                    int activeNode = SelectActiveNode();

                    var arc = Graph.Arcs.FirstOrDefault(a => a.Key.Item1 == activeNode && a.Value > 0);
                    if (arc.Key != null)
                    {
                        int minUnit = Math.Min(ExcessFlows[activeNode], arc.Value);

                        Graph.UpdateArc(activeNode, arc.Key.Item2, -minUnit);
                        Graph.UpdateArc(arc.Key.Item2, activeNode, minUnit);
                    }
                    else
                    {
                        int minDistance = int.MaxValue;

                        foreach (var a in Graph.Arcs.Where(a => a.Key.Item1 == activeNode && a.Value > 0))
                        {
                            int distance = Distances[a.Key.Item2] + 1;
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                            }
                        }

                        Distances[activeNode] = minDistance;
                    }

                    Write();
                }

                Write();
            }

            private Dictionary<int, int> CalculateDistances()
            {
                Dictionary<int, int> distances = new();

                foreach (int node in Graph.Nodes)
                {
                    distances[node] = 0;
                }

                distances[Sink] = 0;

                Queue<int> queue = new();
                queue.Enqueue(Sink);

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();

                    foreach (int neighbor in Graph.GetNeighbors(node))
                    {
                        int residualCapacity = Graph.GetCapacity(neighbor, node);

                        if (residualCapacity > 0 && distances[neighbor] == 0)
                        {
                            distances[neighbor] = distances[node] + 1;
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                distances[1] = Graph.Nodes.Count;

                return distances;
            }

            private int SelectActiveNode()
            {
                foreach (var arc in Graph.Arcs)
                {
                    int fromNode = arc.Key.Item1;
                    int toNode = arc.Key.Item2;
                    int residualCapacity = arc.Value;

                    if (residualCapacity > 0 && Distances[fromNode] > Distances[toNode] && ExcessFlows[fromNode] > 0)
                    {
                        return fromNode;
                    }
                }

                return -1;
            }

            private Dictionary<int, int> CalculateExcessFlows()
            {
                Dictionary<int, int> excessFlows = new();

                foreach (int node in Graph.Nodes)
                {
                    if (node != Source && node != Sink)
                    {
                        int inflow = 0;
                        int outflow = 0;

                        foreach (var arc in Graph.Arcs)
                        {
                            int fromNode = arc.Key.Item1;
                            int toNode = arc.Key.Item2;
                            int capacity = arc.Value;

                            if (fromNode == node)
                                outflow += capacity;

                            if (toNode == node)
                                inflow += capacity;
                        }

                        excessFlows[node] = inflow - outflow;
                    }
                }

                excessFlows[Source] = 0;
                excessFlows[Sink] = 0;

                return excessFlows;
            }

            public void Write()
            {
                //Console.Write("\nArcs - r: ");
                //Graph.Arcs.ToList().ForEach(p => { Console.Write($"{p.Key} - {p.Value} "); });
                Graph.Write();
            }
            #endregion
        }
    }
}
