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
            for (int j = 1; j < Columns[0].Nodes.Count - 1; j++)
            {
                Column c = new Column();
                for (int i = 1; i < Columns.Count - 1; i++)
                {
                    List<int> values = new List<int>();
                    values.Add(Columns[i - 1].Nodes[j - 1].Value);
                    values.Add(Columns[i - 1].Nodes[j].Value);
                    values.Add(Columns[i - 1].Nodes[j + 1].Value);
                
                    values.Add(Columns[i].Nodes[j - 1].Value);
                    values.Add(Columns[i].Nodes[j].Value);
                    values.Add(Columns[i].Nodes[j + 1].Value);
                
                    values.Add(Columns[i + 1].Nodes[j - 1].Value);
                    values.Add(Columns[i + 1].Nodes[j].Value);
                    values.Add(Columns[i + 1].Nodes[j + 1].Value);
                    c.Nodes.Add(new Node(Convert.ToInt32(values.Average())));
                }
                m.Columns.Add(c);
            }

            Columns = m.Columns;
        }
        
        // I wish I had worked with rows instead of columns... 
        public override string ToString()
        {
            char[] greyScaleChars = new char[]{'.', ':', '-', '=', '+', '*', '#', '%', '@'};
            
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
    }
}