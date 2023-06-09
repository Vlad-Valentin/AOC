using AOC;

List<int> nodes = new() { 1, 2, 3, 4, 5 };
//Dictionary<Tuple<int, int>, int> arcs = new() {
//    { Tuple.Create(1, 2), 10 },
//    { Tuple.Create(1, 3), 12 },
//    { Tuple.Create(2, 3), 10 },
//    { Tuple.Create(2, 4), 3 },
//    { Tuple.Create(2, 5), 7 },
//    { Tuple.Create(3, 5), 5 },
//    { Tuple.Create(4, 6), 5 },
//    { Tuple.Create(5, 6), 15 }
//};

Dictionary<Tuple<int, int>, int> arcs = new() {
    { Tuple.Create(1, 2), 8 },
    { Tuple.Create(1, 3), 6 },
    { Tuple.Create(2, 3), 2 },
    { Tuple.Create(2, 4), 5 },
    { Tuple.Create(2, 5), 2 },
    { Tuple.Create(3, 2), 1 },
    { Tuple.Create(3, 5), 7 },
    { Tuple.Create(4, 5), 6 }
};

Graph graph = new(nodes, arcs);

FordFulkerson fordFulkerson = new(graph);
fordFulkerson.Apply();

