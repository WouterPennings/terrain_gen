using System.Collections.Generic;

namespace terrain_gen
{
    public class Column
    {
        public List<Node> Nodes { get; set; } = new();

        public Column() { }
        
        public Column(int count, int minHeight, int maxHeight)
        {
            for (int i = 0; i < count; i++)
                Nodes.Add(new Node(minHeight, maxHeight));
        }

        public override string ToString()
        {
            string str = "";

            foreach (Node n in Nodes) 
                str += $"{n.ToString()}";
            
            return str;
        }
    }
}