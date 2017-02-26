using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToMakeATriangle
{
    //3.8284271247461903
    class Polygon
    {
        public Point[] pointmas {get; set; }
        public Edge[] masedge { get; }
        public int sizes;
        public Polygon(int size,Point [] pointmas1)
        {
            this.sizes = size;
            this.pointmas = pointmas1;
            masedge = new Edge[sizes];
            for (int i = 0; i < masedge.Length - 1; i++)
            {
                masedge[i] = new Edge(pointmas[i], pointmas[i + 1]);
            }
            masedge[sizes - 1] = new Edge(pointmas[sizes - 1], pointmas[0]);

        } 
        public double Area()
        {
            double areaofpolygon1 = 0;
            for (int i = 0; i < pointmas.Length - 1; i++)
            {
                areaofpolygon1 += pointmas[i].x * pointmas[i + 1].y - pointmas[i + 1].x * pointmas[i].y;
            }
            double areaofpolygon2 = 0;
            areaofpolygon2 += pointmas[pointmas.Length - 1].x * pointmas[0].y - pointmas[0].x * pointmas[pointmas.Length - 1].y;
            double half = 0.5;
            double areaofpolygon = Math.Abs(half * (areaofpolygon1 + areaofpolygon2));
            return areaofpolygon;
        }
        public double Perimeter()
        {
            double perimeter = 0;
            for (int i = 0; i < masedge.Length; i++)
            {
                perimeter += masedge[i].length;
            }
            return perimeter;
        }
    }
}
