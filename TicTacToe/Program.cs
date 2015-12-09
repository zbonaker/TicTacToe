using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("There are 19,683 board layouts possible. Which one will you play?");
            Console.WriteLine("");
            Console.WriteLine("What is your name?");

            string playerName = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Hi {0}; let's begin!", playerName);
            Console.WriteLine("");

            string grid1 = "1";
            string grid2 = "2";
            string grid3 = "3";
            string grid4 = "4";
            string grid5 = "5";
            string grid6 = "6";
            string grid7 = "7";
            string grid8 = "8";
            string grid9 = "9";

            Console.WriteLine("_{0}_|_{1}_|_{2}_\n_{3}_|_{4}_|_{5}_\n {6} | {7} | {8} \n ",
                grid1,
                grid2,
                grid3,
                grid4,
                grid5,
                grid6,
                grid7,
                grid8,
                grid9);

            Console.WriteLine("Select a number to place your X:");
            
            var userInput = Console.ReadLine();

            if (userInput == "1")
            {
                grid1 = "X";
            }
            else if (userInput == "2")
            {
                grid2 = "X";
            }
            else if (userInput == "3")
            {
                grid3 = "X";
            }
            else if (userInput == "4")
            {
                grid4 = "X";
            }
            else if (userInput == "5")
            {
                grid5 = "X";
            }
            else if (userInput == "6")
            {
                grid6 = "X";
            }
            else if (userInput == "7")
            {
                grid7 = "X";
            }
            else if (userInput == "8")
            {
                grid8 = "X";
            }
            else if (userInput == "9")
            {
                grid9 = "X";
            }

            Console.WriteLine("");
            Console.WriteLine("_{0}_|_{1}_|_{2}_\n_{3}_|_{4}_|_{5}_\n {6} | {7} | {8} \n ",
                grid1,
                grid2,
                grid3,
                grid4,
                grid5,
                grid6,
                grid7,
                grid8,
                grid9);

            Console.ReadLine();
        }

        public static void DrawGameGrid()
        {
            //how can I create a method to draw the game grid after each move is made?
        }
    }
}
