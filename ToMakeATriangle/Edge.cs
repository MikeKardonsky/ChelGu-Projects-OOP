using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToMakeATriangle
{
    class Edge
    {
        Point x1 { get; set; }
        Point x2 { get; set; }
        public double length;
        public Edge(Point x1, Point x2)
        {
            this.x1 = x1;
            this.x2 = x2;
            length = Math.Sqrt(Math.Pow((x1.x - x2.x), 2) + Math.Pow((x1.y - x2.y), 2));
        }
    }
}
