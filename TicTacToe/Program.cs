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
        private static string[] _gameGrid = new string[] { "1", "2", "3", //first row of grid (index 0 - 2)
                                "4", "5", "6", //second row of grid (index 3 - 5)
                                "7", "8", "9" }; //third row of grid (index 6 - 8)

        private static int _movesPlayed = 0;

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
                DrawGameGrid();
                UserMove();
                endGame = CheckWinner();
                if (endGame == true)
                {
                    DrawGameGrid();
                    break;
                }
                DrawGameGrid();
                ComputerMove();
                endGame = CheckWinner();
                if (endGame == true)
                {
                    DrawGameGrid();
                    break;
                }

            }

            Console.ReadLine();
        }

        private static void DrawGameGrid()
        {
            Console.WriteLine("");
            Console.WriteLine("_{0}_|_{1}_|_{2}_\n_{3}_|_{4}_|_{5}_\n {6} | {7} | {8}",
                _gameGrid[0], _gameGrid[1], _gameGrid[2],
                _gameGrid[3], _gameGrid[4], _gameGrid[5],
                _gameGrid[6], _gameGrid[7], _gameGrid[8]);
            Console.WriteLine("\n");
        }

        private static void UserMove()
        {
            Console.WriteLine("Select a number to place your X:");

            var userInput = Console.ReadLine();
            
            int inputParsed;
            if (int.TryParse(userInput, out inputParsed))
            {
                if (ValidInput(inputParsed))
                {
                    _gameGrid[inputParsed - 1] = "X";
                }
                else
                {
                    Console.WriteLine("\nI couldn't find your move on the game grid!");
                    UserMove();
                }
            }
            else
            {
                Console.WriteLine("\nI couldn't find your move on the game grid!");
                UserMove();
            }

            _movesPlayed++;
        }

        private static bool ValidInput(int inputParsed)
        {
            //Check that input is between 1 and 9 and selected location has not already been played
            return inputParsed >= 1 && inputParsed <= 9 && (_gameGrid[inputParsed - 1] != "X" && _gameGrid[inputParsed - 1] != "O");
        }

        private static void ComputerMove()
        {
            Console.WriteLine("OK, my turn. I choose...");

            ArrayList validMoves = new ArrayList();
            for (int i = 0; i < _gameGrid.Length; i++) //create a list of valid indexes in the game grid array
            {
                int intParsed;
                if (int.TryParse(_gameGrid[i], out intParsed))
                    validMoves.Add(i);
            }

            Random rnd = new Random();
            int idx = rnd.Next(validMoves.Count); //pick a random index from validMoves
            var move = Convert.ToInt32(validMoves[idx]); //assign the value of the random index
            _gameGrid[move] = "O";

            _movesPlayed++;
        }

        private static bool CheckWinner()
        {
            string message = "";
            if (_movesPlayed % 2 == 0)
                message = "I win! Better luck next time!";
            else
                message = "Congratulations, you win!";

            if ((_gameGrid[0] == _gameGrid[1] && _gameGrid[1] == _gameGrid[2]) ||
                (_gameGrid[3] == _gameGrid[4] && _gameGrid[4] == _gameGrid[5]) ||
                (_gameGrid[6] == _gameGrid[7] && _gameGrid[7] == _gameGrid[8]) ||
                (_gameGrid[0] == _gameGrid[3] && _gameGrid[3] == _gameGrid[6]) ||
                (_gameGrid[1] == _gameGrid[4] && _gameGrid[4] == _gameGrid[7]) ||
                (_gameGrid[2] == _gameGrid[5] && _gameGrid[5] == _gameGrid[8]) ||
                (_gameGrid[0] == _gameGrid[4] && _gameGrid[4] == _gameGrid[8]) ||
                (_gameGrid[2] == _gameGrid[4] && _gameGrid[4] == _gameGrid[6]))
            {
                Console.WriteLine(message);
                return true;
            }
           
            else if (_movesPlayed == 9)
            {
                Console.WriteLine("The game is a draw!");
                return true;
            }

            return false;
        }
    }
}
