using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToMakeATriangle
{
    class Triangle
    {
        Point a { get; set; }
        Point b { get; set; }
        Point c { get; set; }
        Edge AB { get; }
        Edge BC { get; }
        Edge AC { get; }
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
            Console.WriteLine("Сторона АВ равна:{0}", AB.length);
            Console.WriteLine("Сторона АС равна:{0}", AC.length);
            Console.WriteLine("Сторона ВС равна:{0}", BC.length);
            Console.WriteLine("Периметр треугольника ABC:{0}", Perimeter());
            Console.WriteLine("Площадь треугольника ABC:{0}", Area());
            Console.WriteLine("Треугольник является прямоугольным?:{0}", Right());
            Console.WriteLine("Треугольник является равнобедренным?:{0}", Isosceles());
        }
        static void PrintInfoAboutTriagle(Triangle triangle)
        {
            Console.WriteLine("Сторона АВ равна:{0}", triangle.AB.length);
            Console.WriteLine("Сторона АС равна:{0}", triangle.AC.length);
            Console.WriteLine("Сторона ВС равна:{0}", triangle.BC.length);
            Console.WriteLine("Периметр треугольника ABC:{0}", triangle.Perimeter());
            Console.WriteLine("Площадь треугольника ABC:{0}", triangle.Area());
            Console.WriteLine("Треугольник является прямоугольным?:{0}", triangle.Right());
            Console.WriteLine("Треугольник является равнобедренным?:{0}", triangle.Isosceles());
        }
        static void Main(string[] args)
        {
            Random Gen = new Random();
            Point a = new Point(1,1);
            Point b = new Point(1, 6);
            Point c = new Point(6, 1);
            Triangle triangle = new Triangle(a, b, c);
            if (triangle.Possible())
            {
                Console.WriteLine("По заданным координатам треугольник возможен");
                PrintInfoAboutTriagle(triangle);
            }
            else Console.WriteLine("По заданным координатам треугольник невозможен.");
            Console.WriteLine();
            Triangle[] Mastriagle = new Triangle[10];
            for (int i = 0; i < Mastriagle.Length; i++)
            {
                double randomx = Gen.Next(0, 20);
                double randomy = Gen.Next(0, 20);
                double randomx1 = Gen.Next(0, 20);
                double randomy1 = Gen.Next(0, 20);
                double randomx2 = Gen.Next(0, 20);
                double randomy2 = Gen.Next(0, 20);
                Point amas = new Point(randomx, randomy);
                Point bmas = new Point(randomx1, randomy1);
                Point cmas = new Point(randomx2, randomy2);
                Mastriagle[i] = new Triangle(amas,bmas,cmas);
                
            } 
            for (int i = 0; i < Mastriagle.Length; i++)
            {
                if (Mastriagle[i].Possible())
                {
                    Console.WriteLine("По заданным координатам {0} треугольник возможен", i);
                    PrintInfoAboutTriagle(Mastriagle[i]);
                    Console.WriteLine();
                }
                else Console.WriteLine("По заданным координатам треугольник невозможен.");
            }
            double sumofareaofmas = 0;
            double countofisoscelestriagle = 0;
            double midarea = 0;
            for (int i = 0; i < Mastriagle.Length; i++)
            {
                if (Mastriagle[i].Possible() && Mastriagle[i].Isosceles())
                {
                    sumofareaofmas += Mastriagle[i].Area();
                    countofisoscelestriagle++;
                }
            }
            if (countofisoscelestriagle == 0)
            {
                Console.WriteLine("К сожалению,равнобедренных треугольников в массиве нет,поэтому их среднюю площадь не вычислить");
            }
            else
            {
               midarea = sumofareaofmas / countofisoscelestriagle;
               Console.WriteLine("Средняя площадь всех равнобедренных треугольников равна {0}", midarea);
            }
            double countofrighttriagle = 0;
            double sumofperimeterofmas = 0;
            double midperimeter = 0;
            for (int i = 0; i < Mastriagle.Length; i++)
            {
                if (Mastriagle[i].Possible() && Mastriagle[i].Right())
                {
                    sumofperimeterofmas += Mastriagle[i].Perimeter();
                    countofrighttriagle++;
                }
            }
            if(countofrighttriagle == 0)
            {
               Console.WriteLine("К сожалению,прямоугольных треугольников в массиве нет,поэтому их средний периметр не вычислить");
            }
            else
            {
                midperimeter = sumofperimeterofmas / countofrighttriagle;
                Console.WriteLine("Средний периметр всех прямоугольных треугольников равен {0}", midperimeter);
            }
            
            Console.ReadKey();
        }
    }
}
