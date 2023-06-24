using AOC;
using AOC.AOC;

public class Program
{
    private static void Main(string[] args)
    {
        //List<int> nodes = new() { 1, 2, 3, 4 };
        ////Dictionary<Tuple<int, int>, int> arcs = new() {
        ////    { Tuple.Create(1, 2), 10 },
        ////    { Tuple.Create(1, 3), 12 },
        ////    { Tuple.Create(2, 3), 10 },
        ////    { Tuple.Create(2, 4), 3 },
        ////    { Tuple.Create(2, 5), 7 },
        ////    { Tuple.Create(3, 5), 5 },
        ////    { Tuple.Create(4, 6), 5 },
        ////    { Tuple.Create(5, 6), 15 }
        ////};

        ////FF
        ////Dictionary<Tuple<int, int>, int> arcs = new() {
        ////    { Tuple.Create(1, 2), 8 },
        ////    { Tuple.Create(1, 3), 6 },
        ////    { Tuple.Create(2, 3), 2 },
        ////    { Tuple.Create(2, 4), 5 },
        ////    { Tuple.Create(2, 5), 2 },
        ////    { Tuple.Create(3, 2), 1 },
        ////    { Tuple.Create(3, 5), 7 },
        ////    { Tuple.Create(4, 5), 6 }
        ////};

        ////GP
        ////Dictionary<Tuple<int, int>, int> arcs = new() {
        ////    { Tuple.Create(1, 2), 7 },
        ////    { Tuple.Create(1, 3), 3 },
        ////    { Tuple.Create(2, 3), 2 },
        ////    { Tuple.Create(2, 4), 4 },
        ////    { Tuple.Create(3, 2), 2 },
        ////    { Tuple.Create(3, 4), 5 }
        ////};

        //Dictionary<Tuple<int, int>, int> arcs = new() {
        //    { Tuple.Create(1, 2), 2 },
        //    { Tuple.Create(1, 3), 4 },
        //    { Tuple.Create(2, 3), 3 },
        //    { Tuple.Create(2, 4), 1 },
        //    { Tuple.Create(3, 4), 5 }
        //};

        //Graph graph = new(nodes, arcs);

        ////FordFulkerson fordFulkerson = new(graph);
        ////fordFulkerson.Apply();

        //GenericPreflow genericPreflow = new(graph);
        //genericPreflow.Apply();

        #region PROBLEM 1
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
        {Tuple.Create(11, 12), 9}
        };

        Graph graph1 = new(nodes1, arcs1);

        Console.WriteLine("\n== 1. FF ==");
        FordFulkerson fordFulkerson1 = new(graph1);
        fordFulkerson1.Apply();

        Console.WriteLine("\n== 1. GP ==");
        GenericPreflow genericPreflow1 = new(graph1);
        genericPreflow1.Apply();

        //graph1.WriteTeamTimes(3);
        //graph1.WriteProjectTimes(11);
        #endregion

        //#region PROBLEM 2
        //// 1 = S
        ////{2, 3, 4, 5, 6} = A
        //// 7 = T
        //List<int> nodes2 = new() { 1, 2, 3, 4, 5, 6, 7 };
        //Dictionary<Tuple<int, int>, int> arcs2 = new()
        //{
        //{Tuple.Create(1, 2), 4},
        //{Tuple.Create(1, 3), 2},
        //{Tuple.Create(2, 3), 2},
        //{Tuple.Create(2, 4), 2},
        //{Tuple.Create(2, 5), 3},
        //{Tuple.Create(3, 6), 5},
        //{Tuple.Create(4, 6), 2},
        //{Tuple.Create(5, 7), 3},
        //{Tuple.Create(6, 5), 1},
        //{Tuple.Create(6, 7), 3}
        //};

        //Graph graph2 = new(nodes2, arcs2);

        //Console.WriteLine("\n== 2. FF ==");
        //FordFulkerson fordFulkerson2 = new(graph2);
        //fordFulkerson2.Apply();

        //Console.WriteLine("\n== 2. GP ==");
        //GenericPreflow genericPreflow2 = new(graph2);
        //genericPreflow2.Apply();

        //graph2.WriteSupplySent(2);
        //graph2.WriteDemandRecevied(6);
        //#endregion
    }
}