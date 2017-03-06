using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Game
    {
        private int Side { get; }
        private int xofnull { get; set; }
        private int yofnull { get; set; }
        public int[,] Numbers { get; set; }
        public Game(params int [] mas)
        {
            int count = 0;
            //bool existnull;
            if (CorrectArray(mas) && CorrectIntSize(mas.Length))
            { 
                Side = (int)Math.Sqrt(mas.Length);
                Numbers = new int[Side, Side];
                for (int i = 0; i < Side; i++)
                {
                    for (int j = 0; j < Side; j++)
                    {
                        if (mas[count] == 0)
                        {
                            xofnull = i;
                            yofnull = j;
                            Numbers[i, j] = mas[count];
                            count++;
                            //existnull = true;
                        }
                        else
                        {
                            Numbers[i, j] = mas[count];
                            count++;
                        }
                    }
                }
            }
            else Console.WriteLine("Значения в данном массиве некорректны или размер поля с данными аргументами не может существовать");
        }
        private bool CorrectArray(int [] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if ((!mas.Contains(i)) || (mas[i] < 0))
                {
                    return false;
                }
            }
            return true;
        }
        private bool CorrectIntSize(int size)
        {
            return ((Math.Sqrt(size) % 1) == 0);
        }
        public 
        static void Main(string[] args)
        {
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
        }
    }
}
