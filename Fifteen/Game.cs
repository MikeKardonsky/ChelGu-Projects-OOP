using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Game
    {
        public int Side { get; }
        private int xOfNull;
        private int yOfNull;
        public int[,] Numbers;
        public Game(int[] mas)
        {          
            Side = (int)Math.Sqrt(mas.Length);
            ToMakeAField(mas);
        }        
        protected int[,] ToMakeAField(int [] mas)
        {
            int count = 0;
            Numbers = new int[Side, Side];
            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    if (mas[count] == 0)
                    {
                        xOfNull = i;
                        yOfNull = j;
                        Numbers[i, j] = mas[count];
                        count++;
                    }
                    else
                    {
                        Numbers[i, j] = mas[count];
                        count++;
                    }
                }
            }
            return Numbers;
        }
        public int[] GetLocation(int value)
        {
            int[] mas = null;
            if ((value < Math.Pow(Side, 2)) && (value >= 0))
            { 
                for (int i = 0; i < Side; i++)
                {
                    for (int j = 0; j < Side; j++)
                    {
                        if (Numbers[i, j] == value)
                            mas = new int[]{ i, j };
                    }
                }                
            }
            return mas;
        }
        public bool CorrectArray(int[] mas)
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
        public bool CorrectIntSize(int size)
        {
            return ((Math.Sqrt(size) % 1) == 0);
        }

    }
}
