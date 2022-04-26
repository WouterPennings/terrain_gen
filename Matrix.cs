using System;
using System.Collections.Generic;
using System.Linq;

namespace terrain_gen
{
    public class Matrix
    {
        public List<Column> Columns { get; set; } = new();

        private Matrix() { }
        
        public Matrix(int xAxis, int yAxis, int minHeight, int maxHeight, int filterSize = 0)
        {
            for (int i = 0; i < xAxis; i++)
                Columns.Add(new Column(yAxis, minHeight, maxHeight));

            if (filterSize < 1) return;
            
            Smooth(filterSize);
        }

        public void Smooth(int size = 1)
        {
            Matrix m = new Matrix();

            for (int i = 0; i < Columns.Count - 2; i++)
            {
                m.Columns.Add(new Column());
            }
            
            for (int nIndex = 1; nIndex < Columns[0].Nodes.Count - 1; nIndex++)
            {
                Column c = new Column();
                Node n = new Node(1);
                for (int cIndex = 1; cIndex < Columns.Count - 1; cIndex++)
                {
                    List<int> values = new List<int>();
                    values.Add(Columns[cIndex - 1].Nodes[nIndex - 1].Value);
                    values.Add(Columns[cIndex - 1].Nodes[nIndex].Value);
                    values.Add(Columns[cIndex - 1].Nodes[nIndex + 1].Value);
                
                    values.Add(Columns[cIndex].Nodes[nIndex - 1].Value);
                    values.Add(Columns[cIndex].Nodes[nIndex].Value);
                    values.Add(Columns[cIndex].Nodes[nIndex + 1].Value);
                
                    values.Add(Columns[cIndex + 1].Nodes[nIndex - 1].Value);
                    values.Add(Columns[cIndex + 1].Nodes[nIndex].Value);
                    values.Add(Columns[cIndex + 1].Nodes[nIndex + 1].Value);
                    n = new Node(Convert.ToInt32(values.Average()));
                    m.Columns[cIndex - 1].Nodes.Add(n);
                }
                
            }

            Columns = m.Columns;
        }

        public string GenerateTerrain()
        {
            //char[] greyScaleChars = new char[]{'.', ':', '-', '=', '+', '*', '#', '%', '@'};
            char[] greyScaleChars = new char[]{'$', '@', 'B', '%', '8', '&', 'W', 'M', '#', '*', 'o', 'a', 'h', 'k', 'b', 'd', 'p', 'q', 'w', 'm', 'Z', 'O', '0', 'Q', 'L', 'C', 'J', 'U', 'Y', 'X', 'z', 'c', 'v', 'u', 'n', 'x', 'r', 'j', 'f', 't', '/', '\\', '|', '(', ')', '1', '{', '}', '[', ']', '?', '-', '_', '+', '~', '<', '>', 'i', '!', 'l', 'I', ';', ':', ',', '"', '^', '`', '\'', '.', ' '};
            
            string str = "";
            
            for (int j = 0; j < Columns[0].Nodes.Count; j++)
            {
                for (int i = 0; i < Columns.Count; i++)
                {
                    str += $"{greyScaleChars[Columns[i].Nodes[j].Value]}";
                }

                str += "\n";
            }
            
            return str;
        }
        
        // I wish I had worked with rows instead of columns... 
        public override string ToString()
        {
            string str = "";
            
            for (int j = 0; j < Columns[0].Nodes.Count; j++)
            {
                for (int i = 0; i < Columns.Count; i++)
                {
                    str += $"{Columns[i].Nodes[j].Value}";
                }

                str += "\n";
            }
            
            return str;
        }
    }
}