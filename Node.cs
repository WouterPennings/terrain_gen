using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace terrain_gen
{
    public class Node
    {
        public int Value { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public Node(int minHeight, int maxHeight)
        {
            Random rand = new Random();
            Value = rand.Next(minHeight, maxHeight);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}