using System;
using System.Collections;
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

        private static int movesPlayed = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("There are 19,683 board layouts possible. Which one will you play?");
            Console.WriteLine("\nWhat is your name?");

            string playerName = Console.ReadLine();

            Console.WriteLine("\nHi {0}; let's begin!", playerName);
            Console.WriteLine();

            bool endGame = false;
            while (endGame == false)
            {
                drawGameGrid();
                userMove();
                endGame = checkWinner();
                if (endGame == true)
                {
                    drawGameGrid();
                    break;
                }
                drawGameGrid();
                computerMove();
                endGame = checkWinner();
                if (endGame == true)
                {
                    drawGameGrid();
                    break;
                }

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
                if (inputParsed >= 1 && inputParsed <= 9 && (gameGrid[inputParsed-1] != "X" && gameGrid[inputParsed-1] != "O"))
                {
                    gameGrid[inputParsed - 1] = "X";
                }
                else
                {
                    Console.WriteLine("\nI couldn't find your move on the game grid!");
                    userMove();
                }
            }
            else
            {
                Console.WriteLine("\nI couldn't find your move on the game grid!");
                userMove();
            }

            movesPlayed++;
        }

        private static void computerMove()
        {
            Console.WriteLine("OK, my turn. I choose...");

            ArrayList validMoves = new ArrayList();
            for (int i = 0; i < gameGrid.Length; i++)
            {
                int intParsed;
                if (int.TryParse(gameGrid[i], out intParsed))
                    validMoves.Add(i);
            }

            Random rnd = new Random();
            int idx = rnd.Next(validMoves.Count); //pick a random index from validMoves
            var move = Convert.ToInt32(validMoves[idx]); //assign the value of the random index
            gameGrid[move] = "O";

            movesPlayed++;
        }

        private static bool checkWinner()
        {
            string youWin = "Congratulations, you win!";
            string cpuWin = "I win! Better luck next time!";

            if ((gameGrid[0] == "X" & gameGrid[1] == "X" & gameGrid[2] == "X") | 
                (gameGrid[3] == "X" & gameGrid[4] == "X" & gameGrid[5] == "X") |
                (gameGrid[6] == "X" & gameGrid[7] == "X" & gameGrid[8] == "X") |
                (gameGrid[0] == "X" & gameGrid[3] == "X" & gameGrid[6] == "X") |
                (gameGrid[1] == "X" & gameGrid[4] == "X" & gameGrid[7] == "X") |
                (gameGrid[2] == "X" & gameGrid[5] == "X" & gameGrid[8] == "X") |
                (gameGrid[0] == "X" & gameGrid[4] == "X" & gameGrid[8] == "X") |
                (gameGrid[2] == "X" & gameGrid[4] == "X" & gameGrid[6] == "X"))
            {
                Console.WriteLine(youWin);
                return true;
            }
            else if ((gameGrid[0] == "O" & gameGrid[1] == "O" & gameGrid[2] == "O") |
                (gameGrid[3] == "O" & gameGrid[4] == "O" & gameGrid[5] == "O") |
                (gameGrid[6] == "O" & gameGrid[7] == "O" & gameGrid[8] == "O") |
                (gameGrid[0] == "O" & gameGrid[3] == "O" & gameGrid[6] == "O") |
                (gameGrid[1] == "O" & gameGrid[4] == "O" & gameGrid[7] == "O") |
                (gameGrid[2] == "O" & gameGrid[5] == "O" & gameGrid[8] == "O") |
                (gameGrid[0] == "O" & gameGrid[4] == "O" & gameGrid[8] == "O") |
                (gameGrid[2] == "O" & gameGrid[4] == "O" & gameGrid[6] == "O"))
            {
                Console.WriteLine(cpuWin);
                return true;
            }
            else if (movesPlayed == 9)
            {
                Console.WriteLine("The game is a draw!");
                return true;
            }

            return false;
        }
    }
}
