using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        private static string[] gameGrid = new string[] { "1", "2", "3", //first row of grid (index 0 - 2)
                                "4", "5", "6", //second row of grid (index 3 - 5)
                                "7", "8", "9" }; //third row of grid (index 6 - 8)

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
                checkWinner();
                drawGameGrid();
                computerMove();
                checkWinner();
            }

            Console.ReadLine();
        }

        private static void drawGameGrid()
        {
            Console.WriteLine("");
            Console.WriteLine("_{0}_|_{1}_|_{2}_\n_{3}_|_{4}_|_{5}_\n {6} | {7} | {8}",
                gameGrid[0], gameGrid[1], gameGrid[2],
                gameGrid[3], gameGrid[4], gameGrid[5],
                gameGrid[6], gameGrid[7], gameGrid[8]);
            Console.WriteLine("\n");
        }

        private static void userMove()
        {
            Console.WriteLine("Select a number to place your X:");

            var userInput = Console.ReadLine();

            int inputParsed;
            if (int.TryParse(userInput, out inputParsed))
            {
                for (int i = 0; i < 9; i++)
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

            for (int i = 0; i < 9; i++)
            {
                int intParsed;
                if (int.TryParse(gameGrid[i], out intParsed))
                {
                    gameGrid[i] = "O";
                    break;
                }
            }
        }

        private static void checkWinner()
        {

            /*
            I could create an array for X and an array for Y;
            Foreach in the gamegrid, write the index of X to the X array & Y to the Y array
            If any of the 8 possible win scenarios exist in the either grid, write win message and exit.
            */
        }
    }
}
