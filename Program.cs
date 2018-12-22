using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newgame0
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            int points = 0;
            int metrixsize = 0;
            do
            {
                Console.WriteLine("plaese enter the cards Arry size:");
                metrixsize = Convert.ToInt32(Console.ReadLine());
            }
            while (metrixsize > 8 || metrixsize <= 0 || metrixsize % 2 != 0);

            int[,] CardsArray = new int[metrixsize, metrixsize];

            for (int j = 1; j <= (metrixsize * metrixsize)/2; j++)
            {
                int counter = 0;
                while (counter < 2)
                {
                    int row = randomGenerator.Next(0, metrixsize );
                    int column = randomGenerator.Next(0, metrixsize );

                    if (CardsArray[row, column] == 0)
                    {
                        CardsArray[row, column] = j;
                        counter++;
                    }
                
                }
            }
            for (int i = 0; i < metrixsize; i++)
            {
                for (int j = 0; j < metrixsize; j++)
                {
                    Console.Write($" [{CardsArray[i, j]}] ");
                }
                Console.WriteLine();
            }

            int row1 = 9;
            int column1 = 9;
            int row2 = 9;
            int column2 = 9;

            while (points < ((metrixsize * metrixsize) / 2))

            {
                while (row1 < 0 || row1 > metrixsize - 1 || column1 < 0 || column1 > metrixsize - 1)
                    { 
                        Console.WriteLine($"please enter a row number between 0-{metrixsize - 1}");
                        row1 = Convert.ToInt32(Console.ReadLine());                   
                    
                        Console.WriteLine($"please enter a column number between 0-{metrixsize - 1}");
                        column1 = Convert.ToInt32(Console.ReadLine());
                    }

                    Console.WriteLine($"your first card:{CardsArray[row1, column1]}");

                    while (row2 < 0 || row2 > metrixsize - 1 || column2 < 0 || column2 > metrixsize - 1)
                    {
                        Console.WriteLine($"please enter a row number between 0-{metrixsize - 1}");
                        row2 = Convert.ToInt32(Console.ReadLine());
                   
                        Console.WriteLine($"please enter a column number between 0-{metrixsize - 1}");
                        column2 = Convert.ToInt32(Console.ReadLine());
                    }

                Console.WriteLine($"your second card:{CardsArray[row2, column2]}");

                if (CardsArray[row1, column1] == CardsArray[row2, column2])
                {
                    CardsArray[row2, column2] = 0;
                    CardsArray[row1, column1] = 0;
                    points++;
                    Console.WriteLine("you got one!");
           
                }
                else
                {
                    Console.WriteLine("try again.....");
                }

                row1 = 9;
                column1 = 9;
                row2 = 9;
                column2 = 9;
            }

            Console.WriteLine("YOU WONNNNNNNN");
        }
    }
}
