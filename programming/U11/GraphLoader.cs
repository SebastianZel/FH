using AlgoDat;

namespace code_ds_graph_gewichtet
{

    public static class GraphLoader
    {
        /// <summary>Loads a graph from a given file. The graph format must be
        /// in the dot-format.
        /// </summary>
        /// <returns>A graph representation</returns>
        public static WeightedGraph<string> Load(string fileName)
        {
            WeightedGraph<string> newGraph = new WeightedGraph<string>();

            string[] dotfile = System.IO.File.ReadAllLines(fileName);

            for(int i = 1; i< dotfile.Length;i++){
                string[] split = dotfile[i].Split(' ','[','=',']');
                double weight =double.Parse(split[4]);
                newGraph.AddEdge(split[0],split[2],weight);
            }
           
            return newGraph;
        }
    }

}