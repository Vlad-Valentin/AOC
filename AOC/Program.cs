using AOC;
using AOC.AOC;

public class Program
{
    private static void Main(string[] args)
    {
        //  1 = S
        // {2, 3, 4 } = E (Team Nodes)
        // {5, 6, 7, 8, 9 } = P (Project Nodes)
        //  10 = T
        // sum(c(S, E)) = sum(c(P, T))
        #region ASSIGNMENT 1    
        List<int> nodes1 = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Dictionary<Tuple<int, int>, int> arcs1 = new()
         {
         {Tuple.Create(1, 2), 9},
         {Tuple.Create(1, 3), 9},
         {Tuple.Create(1, 4), 9},

         {Tuple.Create(2, 5), 3},
         {Tuple.Create(2, 6), 8},
         {Tuple.Create(2, 7), 3},
         {Tuple.Create(2, 9), 6},

         {Tuple.Create(3, 5), 3},
         {Tuple.Create(3, 6), 8},
         {Tuple.Create(3, 8), 7},
         {Tuple.Create(3, 9), 6},

         {Tuple.Create(4, 7), 3},
         {Tuple.Create(4, 8), 7},
         {Tuple.Create(4, 9), 6},

         {Tuple.Create(5, 10), 3},
         {Tuple.Create(6, 10), 8},
         {Tuple.Create(7, 10), 3},
         {Tuple.Create(8, 10), 7},
         {Tuple.Create(9, 10), 6}
         };

        Graph graph1 = new(nodes1, arcs1);

        Console.WriteLine("\t\t\t\t\t== ASSIGNMENT 1 ==");

        Console.WriteLine("\n\n\t== 1. Ford-Fulkerson ==");
        FordFulkerson fordFulkerson1 = new(graph1);
        fordFulkerson1.Apply();
        fordFulkerson1.Write();

        graph1.WriteTeamTimes(3, 5, 9);
        graph1.WriteProjectTimes(9, 2, 4);

        arcs1 = new()
        {
         {Tuple.Create(1, 2), 9},
         {Tuple.Create(1, 3), 9},
         {Tuple.Create(1, 4), 9},

         {Tuple.Create(2, 5), 3},
         {Tuple.Create(2, 6), 8},
         {Tuple.Create(2, 7), 3},
         {Tuple.Create(2, 9), 6},

         {Tuple.Create(3, 5), 3},
         {Tuple.Create(3, 6), 8},
         {Tuple.Create(3, 8), 7},
         {Tuple.Create(3, 9), 6},

         {Tuple.Create(4, 7), 3},
         {Tuple.Create(4, 8), 7},
         {Tuple.Create(4, 9), 6},

         {Tuple.Create(5, 10), 3},
         {Tuple.Create(6, 10), 8},
         {Tuple.Create(7, 10), 3},
         {Tuple.Create(8, 10), 7},
         {Tuple.Create(9, 10), 6}
         };
        graph1 = new(nodes1, arcs1);

        Console.WriteLine("\n\n\t== 1. Generic Preflow ==");
        GenericPreflow genericPreflow1 = new(graph1);
        genericPreflow1.Apply();
        genericPreflow1.Write();

        graph1.WriteTeamTimes(3, 5, 9);
        graph1.WriteProjectTimes(9, 2, 4);
        #endregion

        // 1 = S
        //{2, 3 } = A (Supplier Nodes)
        //{4, 5 } = A' (Transit Nodes)
        //{6, 7 } = W (Warehouse Nodes) 
        // 8 = T
        // e(A) < 0; e(A') = 0, e(W) > 0
        #region ASSIGNMENT 2
        List<int> nodes2 = new() { 1, 2, 3, 4, 5, 6, 7, 8 };
        Dictionary<Tuple<int, int>, int> arcs2 = new()
        {
        {Tuple.Create(1, 2), 3},
        {Tuple.Create(1, 3), 4},

        {Tuple.Create(2, 3), 5},
        {Tuple.Create(2, 4), 2},
        {Tuple.Create(2, 7), 1},

        {Tuple.Create(3, 5), 3},
        {Tuple.Create(3, 7), 5},

        {Tuple.Create(4, 6), 2},
        {Tuple.Create(5, 6), 3},

        {Tuple.Create(6, 7), 1},
        {Tuple.Create(6, 8), 2},

        {Tuple.Create(7, 8), 3}
        };

        Graph graph2 = new(nodes2, arcs2);

        List<int> transitNodes = new() { 4, 5 };

        Console.WriteLine("\n\n\t\t\t\t\t== ASSIGNMENT 2 ==");

        Console.WriteLine("\n\n\t== 2. Ford-Fulkerson ==");
        FordFulkerson fordFulkerson2 = new(graph2);
        fordFulkerson2.Apply();
        fordFulkerson2.Write();

        graph2.WriteSupplierSent(2, 6, 7, transitNodes);
        graph2.WriteWarehouseReceived(6, 2, 3, transitNodes);

        arcs2 = new()
        {
        {Tuple.Create(1, 2), 3},
        {Tuple.Create(1, 3), 4},

        {Tuple.Create(2, 3), 5},
        {Tuple.Create(2, 4), 2},
        {Tuple.Create(2, 7), 1},

        {Tuple.Create(3, 5), 3},
        {Tuple.Create(3, 7), 5},

        {Tuple.Create(4, 6), 2},
        {Tuple.Create(5, 6), 3},

        {Tuple.Create(6, 7), 1},
        {Tuple.Create(6, 8), 2},

        {Tuple.Create(7, 8), 3}
        };
        graph2 = new(nodes2, arcs2);

        Console.WriteLine("\n\n\t== 2. Generic Preflow ==");
        GenericPreflow genericPreflow2 = new(graph2);
        genericPreflow2.Apply();
        genericPreflow2.Write();

        graph2.WriteSupplierSent(2, 6, 7, transitNodes);
        graph2.WriteWarehouseReceived(6, 2, 3, transitNodes);
        #endregion
    }
}