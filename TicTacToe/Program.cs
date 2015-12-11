using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        private static string[] gameGrid = new string[] { "_", "1", "_|_", "2", "_|_", "3", "_", //first row of grid (index 0 - 6, count 7)
                                "_", "4", "_|_", "5", "_|_", "6", "_", //second row of grid (index 7 - 13; count 7
                                " ", "7", " | ", "8", " | ", "9" }; //third row of grid (index 14 - 19; count 6)

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("There are 19,683 board layouts possible. Which one will you play?");
            Console.WriteLine("\nWhat is your name?");

            string playerName = Console.ReadLine();

            Console.WriteLine("\nHi {0}; let's begin!", playerName);
            Console.WriteLine();

            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    drawGameGrid();
                    userMove();
                    Console.WriteLine("\nThe grid is now full! I need logic to know who wins!");
                    break;
                }
                drawGameGrid();
                userMove();
                drawGameGrid();
                computerMove();
            }

            Console.ReadLine();
        }

        private static void drawGameGrid()
        {
            Console.WriteLine("");

            for (int i = 0; i < 7; i++)
            {
                string grid = gameGrid[i];
                Console.Write(grid);
            }
            Console.WriteLine();
            for (int i = 7; i < 14; i++)
            {
                string grid = gameGrid[i];
                Console.Write(grid);
            }
            Console.WriteLine();
            for (int i = 14; i < 20; i++)
            {
                string grid = gameGrid[i];
                Console.Write(grid);
            }

            Console.WriteLine("\n");
        }

        private static void userMove()
        {
            Console.WriteLine("Select a number to place your X:");

            var userInput = Console.ReadLine();

            int inputParsed;
            if (int.TryParse(userInput, out inputParsed))
            {
                for (int i = 0; i < 20; i++)
                {
                    if (userInput == gameGrid[i])
                    {
                        gameGrid[i] = "X";
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nI couldn't find your move on the game grid!");
                userMove();
            }
        }

        private static void computerMove()
        {
            Console.WriteLine("OK, my turn. I choose...");

            for (int i = 0; i < 20; i++)
            {
                int intParsed;
                if (int.TryParse(gameGrid[i], out intParsed))
                {
                    gameGrid[i] = "O";
                    break;
                }
            }
        }
    }
}
