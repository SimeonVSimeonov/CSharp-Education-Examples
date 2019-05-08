using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Most_Reliable_Path
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int to, double weight)
        {
            this.To = to;
            this.Weight = weight;
        }

        public int To { get; private set; }

        public double Weight { get; private set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
}
