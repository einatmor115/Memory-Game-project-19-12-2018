using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newgameproj_with1chalange
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomGenerator = new Random();
            int pointsplayer1 = 0;
            int pointsplayer2 = 0;
            int metrixsize = 0;
            int[,] CardsArray;
            int interaction = 0;

            CreateMetrix(randomGenerator, out metrixsize, out CardsArray);

            PrintMetrix(metrixsize, CardsArray);

            bool whoplaynow = true;

            while (whoplaynow == true && pointsplayer1 != metrixsize * metrixsize / 2)
            {
                Console.WriteLine($"player 1 is palying now");
                interaction = 0;
                playTurn(ref pointsplayer1, metrixsize, CardsArray, ref whoplaynow, ref interaction);
                Console.WriteLine($"points player 1: {pointsplayer1}");
                Console.WriteLine($"points player 2: {pointsplayer2}");
            }

            while (whoplaynow == false && pointsplayer2 != metrixsize * metrixsize / 2)

            {
                Console.WriteLine($"player 2 is palying now");
                interaction = 0;
                playTurn(ref pointsplayer2, metrixsize, CardsArray, ref whoplaynow, ref interaction);
                Console.WriteLine($"points player 1: {pointsplayer1}");
                Console.WriteLine($"points player 2: {pointsplayer2}");
            }

            if (pointsplayer1 == (metrixsize * metrixsize) / 2 || pointsplayer2 == (metrixsize * metrixsize) / 2)
            {
                if (pointsplayer1 > pointsplayer2)
                {
                    Console.WriteLine($"player 1 won!!!!!!!!!!!!");
                }

                else
                {
                    Console.WriteLine($"player 2 won!!!!!!!!!!!!");
                }
            }
            else if (pointsplayer1 == pointsplayer2 && pointsplayer1 == metrixsize)
            {
                Console.WriteLine($"its a tie(:");
            }
        }

        private static void playTurn(ref int points, int metrixsize, int[,] CardsArray, ref bool turn, ref int interaction)
        {
            int row1 = 9;
            int column1 = 9;
            int row2 = 9;
            int column2 = 9;

            while (points < ((metrixsize * metrixsize) / 2) && interaction == 0)
            {
                row1 = 9;
                column1 = 9;
                row2 = 9;
                column2 = 9;

                EnterRowAndColumn(metrixsize, CardsArray, ref row1, ref column1, ref row2, ref column2);

                interaction = 1;

                if (CardsArray[row1, column1] == CardsArray[row2, column2])
                {
                    CardsArray[row2, column2] = 0;
                    CardsArray[row1, column1] = 0;
                    points++;
                    Console.WriteLine("you got one!");
                }

                else
                {
                    Console.WriteLine("oops not the same card.....");
                }

                turn = WhoTurnIsIt(CardsArray, turn, row1, column1, row2, column2);
            }
        }

        private static void EnterRowAndColumn(int metrixsize, int[,] CardsArray, ref int row1, ref int column1, ref int row2, ref int column2)
        {
            PrintMetrixHidden(metrixsize, CardsArray);
            while (row1 < 0 || row1 > metrixsize - 1 || column1 < 0 || column1 > metrixsize - 1 || CardsArray[row1, column1] == 0)
            {
                Console.WriteLine($"please enter a row number between 0-{metrixsize - 1}");
                row1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"please enter a column number between 0-{metrixsize - 1}");
                column1 = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine($"your first card:{CardsArray[row1, column1]}");
            PrintMetrixAfterGuess(metrixsize, CardsArray, row1, column1);

            while (row2 < 0 || row2 > metrixsize - 1 || column2 < 0 || column2 > metrixsize - 1 || CardsArray[row2, column2] == 0)
            {
                Console.WriteLine($"please enter a row number between 0-{metrixsize - 1}");
                row2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"please enter a column number between 0-{metrixsize - 1}");
                column2 = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine($"your second card:{CardsArray[row2, column2]}");
            PrintMetrixAfterGuess(metrixsize, CardsArray, row2, column2);
        }

        private static bool WhoTurnIsIt(int[,] CardsArray, bool turn, int row1, int column1, int row2, int column2)
        {
            if (turn == true && CardsArray[row1, column1] != CardsArray[row2, column2])
            {
                turn = false;
            }
            else if (turn == true && CardsArray[row1, column1] == CardsArray[row2, column2])
            {
                turn = true;

            }
            else if (turn == false && CardsArray[row1, column1] != CardsArray[row2, column2])
            {
                turn = true;
            }
            else if (turn == false && CardsArray[row1, column1] == CardsArray[row2, column2])
            {
                turn = false;
            }
            else
            {
                turn = false;
            }

            return turn;
        }

        private static void PrintMetrix(int metrixsize, int[,] CardsArray)
        {
            for (int i = 0; i < metrixsize; i++)
            {
                for (int j = 0; j < metrixsize; j++)
                {
                    Console.Write($" [{CardsArray[i, j]}] ");
                }
                Console.WriteLine();
            }
        }
        private static void PrintMetrixHidden(int metrixsize, int[,] CardsArray)
        {
            for (int i = 0; i < metrixsize; i++)
            {
                for (int j = 0; j < metrixsize; j++)
                {
                    if (CardsArray[i, j] == 0)
                    {
                        Console.Write($" [{CardsArray[i, j]}] ");
                    }
                    else
                    {
                        Console.Write(" [X] ");
                    }
                }
                Console.WriteLine();
            }
        }
        private static void PrintMetrixAfterGuess(int metrixsize, int[,] CardsArray,int row, int column)
        {
            for (int i = 0; i < metrixsize; i++)
            {
                for (int j = 0; j < metrixsize; j++)
                {
                    if (CardsArray[i, j] == 0)
                    {
                        Console.Write($" [{CardsArray[i, j]}] ");
                    }

                    else if (row == i && column == j)
                        {
                            Console.Write($" [{CardsArray[row, column]}] ");
                        }

                    else
                    {                       
                            Console.Write(" [X] ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void CreateMetrix(Random randomGenerator, out int metrixsize, out int[,] CardsArray)
        {
            do
            {
                Console.WriteLine("plaese enter the cards Arry size:");
                metrixsize = Convert.ToInt32(Console.ReadLine());
            }
            while (metrixsize > 8 || metrixsize <= 0 || metrixsize % 2 != 0);

            CardsArray = new int[metrixsize, metrixsize];
            for (int j = 1; j <= (metrixsize * metrixsize) / 2; j++)
            {
                int counter = 0;
                while (counter < 2)
                {
                    int row = randomGenerator.Next(0, metrixsize);
                    int column = randomGenerator.Next(0, metrixsize);

                    if (CardsArray[row, column] == 0)
                    {
                        CardsArray[row, column] = j;
                        counter++;
                    }
                }
            }
        }
    }
}