using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Program
    {   
        static void Main(string[] args)
        {
            //int[] mas = { 1, 2, 3, 4, 5, 6, 7, 8, 0};
            int [] mas = Read.ReadFromCSV("text.csv");
            Game game = new Game(mas);
            if (game.CorrectArray(mas) && game.CorrectIntSize(mas.Length))
            {
               Console.WriteLine("Создаю игровое поле!По следующему массиву:");
               for(int i = 0;i < mas.Length;i++)
                {
                    Console.Write(mas[i] + " ");
                }
            }
            else throw new ArgumentException("Значения в данном массиве некорректны или размер поля с данными аргументами не может существовать");
            Console.WriteLine();
            Print.PrintInfo(game.Numbers);
            int pyatnashka = 5;
            if (game.GetLocation(pyatnashka) != null)
            {               
                Console.WriteLine("Позиция числа 5:x = {0},y = {1}" ,game.GetLocation(5).x,game.GetLocation(5).y);             
            }
            else throw new ArgumentException("Данное число не удалось найти");
            int pyatnashka1 = 8;
            if (game.ShiftOrImpossible(pyatnashka1))
            {
                Print.PrintInfo(game.Numbers);
            }
            else throw new ArgumentException("Данное число не удалось найти или невозможно поменять местами с нулём");
            Console.ReadLine();
        }
    }
}
