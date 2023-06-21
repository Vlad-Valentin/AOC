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

        List<int> teams = new() { 1, 2, 3 }; // Echipele disponibile
        List<int> projects = new() { 1, 2, 3, 4 }; // Proiectele disponibile

        // Dicționar pentru a reține timpul necesar pentru fiecare proiect
        Dictionary<int, int> projectTimes = new()
{
    { 1, 3 },
    { 2, 5 },
    { 3, 2 },
    { 4, 4 }
};

        // Dicționar pentru a reține mulțimea de proiecte la care poate contribui fiecare echipă
        Dictionary<int, List<int>> teamProjects = new()
{
    { 1, new List<int> { 1, 2 } },
    { 2, new List<int> { 2, 3 } },
    { 3, new List<int> { 3, 4 } }
};

        // Dicționar pentru a reține timpul de lucru maxim alocat fiecărei echipe
        Dictionary<int, int> teamWorkTimes = new()
{
    { 1, 5 },
    { 2, 4 },
    { 3, 3 }
};

        Graph graph = new Graph();

        // Adăugăm nodurile reprezentând echipele și proiectele în graf
        foreach (int team in teams)
        {
            graph.AddNode(team);
        }

        foreach (int project in projects)
        {
            graph.AddNode(project);
        }

        // Adăugăm arcele între echipe și proiecte, cu capacitățile corespunzătoare
        foreach (var entry in teamProjects)
        {
            int team = entry.Key;
            List<int> teamProjectList = entry.Value;

            foreach (int project in teamProjectList)
            {
                int capacity = projectTimes[project];
                graph.AddArc(team, project, capacity);
            }
        }

        // Adăugăm arcele între proiecte și sursă, cu capacitățile corespunzătoare
        foreach (int project in projects)
        {
            int capacity = projectTimes[project];
            graph.AddArc(project, graph.Nodes.First(), capacity);
        }

        // Adăugăm arcele între echipe și destinație, cu timpii de lucru aferenți fiecărei echipe
        foreach (var entry in teamWorkTimes)
        {
            int team = entry.Key;
            int workTime = entry.Value;
            graph.AddArc(team, graph.Nodes.Last(), workTime);
        }

        //graph.Write();

        GenericPreflow genericPreflow = new(graph);
        genericPreflow.Apply();
    }
}