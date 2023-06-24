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

                Source = graph.Nodes.ToList().First();
                Sink = graph.Nodes.ToList().Last();

                ExcessFlows = new Dictionary<int, int>();
                foreach (var node in Graph.Nodes)
                {
                    ExcessFlows[node] = 0;
                }
            }
            #endregion

            #region Functions
            public void Apply()
            {
                InitExcessFlows();

                Distances = CalculateDistances();

                while (SelectActiveNode() != -1)
                {
                    int activeNode = SelectActiveNode();

                    var arc = SelectValidArc(activeNode);
                    if (arc.Key != Tuple.Create(-1, -1) && arc.Value != 0)
                    {
                        int minUnit = Math.Min(ExcessFlows[activeNode], arc.Value);

                        Graph.UpdateArc(activeNode, arc.Key.Item2, -minUnit);
                        Graph.UpdateArc(arc.Key.Item2, activeNode, minUnit);

                        ExcessFlows[activeNode] -= minUnit;
                        ExcessFlows[arc.Key.Item2] += minUnit;
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

            private void InitExcessFlows()
            {
                Dictionary<int, int> arcs = new();
                ExcessFlows[Source] = 0;

                foreach (var arc in Graph.Arcs.Where(a => a.Key.Item1 == Source))
                {
                    ExcessFlows[arc.Key.Item2] = arc.Value;
                    ExcessFlows[Source] -= arc.Value;

                    arcs[arc.Key.Item2] = arc.Value;
                }

                foreach (var a in arcs)
                {
                    Graph.UpdateArc(Source, a.Key, -a.Value);
                    Graph.UpdateArc(a.Key, Source, a.Value);
                }
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

                distances[Source] = Graph.Nodes.Count;

                return distances;
            }

            private int SelectActiveNode()
            {
                foreach (var node in Graph.Nodes)
                {
                    if (Distances[node] > 0 && ExcessFlows[node] > 0)
                    {
                        return node;
                    }
                }

                return -1;
            }

            private KeyValuePair<Tuple<int, int>, int> SelectValidArc(int x)
            {
                foreach (var arc in Graph.Arcs.Where(a => a.Key.Item1 == x))
                {
                    if (Distances[arc.Key.Item1] == Distances[arc.Key.Item2] + 1 && arc.Value > 0)
                    {
                        return arc;
                    }
                }

                return new KeyValuePair<Tuple<int, int>, int>(Tuple.Create(-1, -1), 0);
            }

            public void Write()
            {
                Console.Write("\n\nE: ");
                ExcessFlows.ToList().ForEach(e => { Console.Write($"\ne({e.Key}) = {e.Value}"); });

                Graph.Write();
            }
            #endregion
        }
    }
}
