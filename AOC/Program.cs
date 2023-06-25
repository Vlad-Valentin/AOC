﻿using AOC;
using AOC.AOC;

public class Program
{
    private static void Main(string[] args)
    {
        #region ASSIGNMENT 1
        // 1 = S
        //{2, 3, 4 } = E
        //{5, 6, 7, 8, 9, 10, 11 } = P
        // 12 = T
        List<int> nodes1 = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        Dictionary<Tuple<int, int>, int> arcs1 = new()
        {
        {Tuple.Create(1, 2), 8},
        {Tuple.Create(1, 3), 8},
        {Tuple.Create(1, 4), 8},
        {Tuple.Create(2, 7), 5},
        {Tuple.Create(2, 8), 2},
        {Tuple.Create(2, 9), 1},
        {Tuple.Create(2, 10), 3},
        {Tuple.Create(3, 5), 2},
        {Tuple.Create(3, 6), 2},
        {Tuple.Create(3, 7), 5},
        {Tuple.Create(3, 9), 1},
        {Tuple.Create(3, 10), 3},
        {Tuple.Create(3, 11), 9},
        {Tuple.Create(4, 6), 2},
        {Tuple.Create(4, 7), 5},
        {Tuple.Create(4, 9), 5},
        {Tuple.Create(4, 11), 9},
        {Tuple.Create(5, 12), 2},
        {Tuple.Create(6, 12), 2},
        {Tuple.Create(7, 12), 5},
        {Tuple.Create(8, 12), 2},
        {Tuple.Create(9, 12), 1},
        {Tuple.Create(10, 12), 3},
        {Tuple.Create(11, 12), 9},
        };

        Graph graph1 = new(nodes1, arcs1);

        Console.WriteLine("\t\t\t\t\t== ASSIGNMENT 1 ==\n\n");

        Console.WriteLine("\n\t== 1. Ford-Fulkerson ==");
        FordFulkerson fordFulkerson1 = new(graph1);
        fordFulkerson1.Apply();

        arcs1 = new()
        {
        {Tuple.Create(1, 2), 8},
        {Tuple.Create(1, 3), 8},
        {Tuple.Create(1, 4), 8},
        {Tuple.Create(2, 7), 5},
        {Tuple.Create(2, 8), 2},
        {Tuple.Create(2, 9), 1},
        {Tuple.Create(2, 10), 3},
        {Tuple.Create(3, 5), 2},
        {Tuple.Create(3, 6), 2},
        {Tuple.Create(3, 7), 5},
        {Tuple.Create(3, 9), 1},
        {Tuple.Create(3, 10), 3},
        {Tuple.Create(3, 11), 9},
        {Tuple.Create(4, 6), 2},
        {Tuple.Create(4, 7), 5},
        {Tuple.Create(4, 9), 5},
        {Tuple.Create(4, 11), 9},
        {Tuple.Create(5, 12), 2},
        {Tuple.Create(6, 12), 2},
        {Tuple.Create(7, 12), 5},
        {Tuple.Create(8, 12), 2},
        {Tuple.Create(9, 12), 1},
        {Tuple.Create(10, 12), 3},
        {Tuple.Create(11, 12), 9},
        };
        graph1 = new(nodes1, arcs1);

        Console.WriteLine("\n\t== 1. Generic Preflow ==");
        GenericPreflow genericPreflow1 = new(graph1);
        genericPreflow1.Apply();

        graph1.WriteTeamTimes(2, 5, 11);
        graph1.WriteProjectTimes(11, 2, 4);
        #endregion

        #region ASSIGNMENT 2
        // 1 = S
        //{2, 3 } = Supplier Nodes
        //{4, 5 } = Transit Nodes
        //{6, 7 } = Warehouse Nodes
        // 8 = T
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

        Console.WriteLine("\n\n\t\t\t\t\t== ASSIGNMENT 2 ==\n\n");

        Console.WriteLine("\n\t== 2. Ford-Fulkerson ==");
        FordFulkerson fordFulkerson2 = new(graph2);
        fordFulkerson2.Apply();

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

        Console.WriteLine("\n\t== 2. Generic Preflow ==");
        GenericPreflow genericPreflow2 = new(graph2);
        genericPreflow2.Apply();

        graph2.WriteSupplierSent(2, 6, 7, transitNodes);
        graph2.WriteWarehouseReceived(6, 2, 3, transitNodes);
        #endregion
    }
}