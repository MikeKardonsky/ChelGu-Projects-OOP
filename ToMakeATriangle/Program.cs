using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToMakeATriangle
{
    class Triangle
    {
        Point a, b, c;
        Edge AB, BC, AC;
        public Triangle(Point a, Point b, Point c)
        {
            AB = new Edge(a, b);
            BC = new Edge(b, c);
            AC = new Edge(a, c);
        }
        public bool Possible()
        {
            return ((AB.length + BC.length) > AC.length) && ((BC.length + AC.length) > AB.length) && ((AB.length + AC.length) > BC.length);
        }
        public double Perimeter()
        {
            return AB.length + BC.length + AC.length;
        }
        public double Area()
        {
            double semiPerimeter = AB.length + BC.length + AC.length / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - AB.length) * (semiPerimeter - BC.length) * (semiPerimeter - AC.length));
        }
        public bool Isosceles()
        {
            if (AB.length == AC.length || AC.length == BC.length || AB.length == BC.length) return true;
            else return false;
        }
        public bool Right()
        {
            if ((AB.length == Math.Sqrt(Math.Pow(BC.length, 2) + Math.Pow(AC.length, 2)))
                      || (BC.length == Math.Sqrt(Math.Pow(AC.length, 2) + Math.Pow(AB.length, 2)))
                      || (AC.length == Math.Sqrt(Math.Pow(AB.length, 2) + Math.Pow(BC.length, 2)))) return true;
            else return false;
        }
        public void PrintInfoAboutTriagle()
        { 
            Console.WriteLine("Периметр треугольника ABC:{0}", Perimeter());
            Console.WriteLine("Площадь треугольника ABC:{0}", Area());
            Console.WriteLine("Треугольник является прямоугольным?:{0}", Right());
            Console.WriteLine("Треугольник является равнобедренным?:{0}", Isosceles());
        }
        static void Main(string[] args)
        {
            Point a = new Point(1,1);
            Point b = new Point(1, 6);
            Point c = new Point(6, 1);
            Triangle triangle = new Triangle(a, b, c);
            if (triangle.Possible())
            {
                Console.WriteLine("По заданным координатам треугольник возможен");
                triangle.PrintInfoAboutTriagle();
            }
            else Console.WriteLine("По заданным координатам треугольник невозможен.");
            Console.WriteLine();
            Triangle[] Mastriagle = new Triangle[10];
            for (int i = 0; i < Mastriagle.Length; i++)
            {
                Mastriagle[i] = new Triangle(a,b,c);
                
            }
            
            int countoftriagle = 0;
            for (int i = 0; i < Mastriagle.Length; i++)
            {
                if (triangle.Possible())
                {
                    Console.WriteLine("По заданным координатам {0} треугольник возможен", i);
                    triangle.PrintInfoAboutTriagle();
                    countoftriagle++;
                    Console.WriteLine();
                }
                else Console.WriteLine("По заданным координатам треугольник невозможен.");
            }
            double Sumofareaofmas = 0;
            for (int i = 0; i < Mastriagle.Length; i++)
            {
                if (Mastriagle[i].Possible() && Mastriagle[i].Isosceles()) Sumofareaofmas += Mastriagle[i].Area();
            }
            double Midarea = Sumofareaofmas / countoftriagle;
            Console.WriteLine("Средняя площадь равна {0}",Midarea);
            double Sumofperimeterofmas = 0;
            for (int i = 0; i < Mastriagle.Length; i++)
            {
                if (Mastriagle[i].Right()) Sumofperimeterofmas += Mastriagle[i].Perimeter();
            }
            double MidPerimeter = Sumofperimeterofmas / countoftriagle;
            Console.WriteLine("Средний периметр равен {0}", MidPerimeter);
            Console.ReadKey();
        }
    }
}
