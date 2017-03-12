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
               // Console.WriteLine("Создаю игровое поле!");
               for(int i = 0;i < mas.Length;i++)
                {
                    Console.WriteLine(mas[i]);
                }
            }
            else throw new ArgumentException("Значения в данном массиве некорректны или размер поля с данными аргументами не может существовать");
            if (game.GetLocation(5) != null)
            {
                Console.WriteLine("Позиция числа 5:");
            }
            else throw new ArgumentException("Данное число не удалось найти");
            Console.ReadLine();
        }
    }
}
