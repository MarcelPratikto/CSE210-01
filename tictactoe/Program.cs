/*
Tic-tac-toe game
*/

using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class Program
    {        
        /*
        Creates board
        Parameters: 
        Returns: board
        */
        static List<string> CreateBoard()
        {
            List<string> board = new List<string>(9);
            for (int i = 0; i < 9; i++)
            {
                board.Add($"{i+1}");
            }
            return board;
        }

        /*
        Edits board
        Parameters: board, index, value
        Returns:
        */
        static void EditBoard(List<string> board, int index, string value)
        {
            board[index] = value;
        }
        
        /*
        Displays board
        Parameters: board
        Returns:
        */
        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine($"- - -");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine($"- - -");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        /*
        Ask the player where they want to put their respective x or o on the board
        Parameters: player
        Returns: index on board
        */
        static int PlayerTurn(List<string> board, string player)
        {            
            // make sure that user input is valid
            bool validInput = false;
            int index = 0;
            while (!validInput)
            {
                Console.WriteLine($"It's Player {player}'s turn. Pick an index: ");
                string userInput = Console.ReadLine();
                if (
                    userInput == "1" ||
                    userInput == "2" ||
                    userInput == "3" ||
                    userInput == "4" ||
                    userInput == "5" ||
                    userInput == "6" ||
                    userInput == "7" ||
                    userInput == "8" ||
                    userInput == "9"
                    )
                {
                    index = int.Parse(userInput) - 1;
                    if (userInput == board[index])
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Please choose an index that has not been chosen yet.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
                        
            return index;
        }

        /*
        Checks if any player has won
        Parameters: board, player
        Returns: True if player won
        */
        static bool isWinner(List<string> board, string player)
        {
            bool win = false;
            // based on index 0
            if (board[0]==player && board[1]==player && board[2]==player)
            {
                win = true;
            }
            if (board[0]==player && board[4]==player && board[8]==player)
            {
                win = true;
            }
            if (board[0]==player && board[3]==player && board[6]==player)
            {
                win = true;
            }
            // based on index 1
            if (board[1]==player && board[4]==player && board[7]==player)
            {
                win = true;
            }
            // based on index 2
            if (board[2]==player && board[4]==player && board[6]==player)
            {
                win = true;
            }
            if (board[2]==player && board[5]==player && board[8]==player)
            {
                win = true;
            }
            // based on index 3
            if (board[3]==player && board[4]==player && board[5]==player)
            {
                win = true;
            }
            // based on index 6
            if (board[6]==player && board[7]==player && board[8]==player)
            {
                win = true;
            }
            return win;
        }

        static void Main(string[] args)
        {
            // Create the board first
            List<string> board = CreateBoard();
            //Console.WriteLine($"board.Count: {board.Count}");
            Console.WriteLine("Board indexes:");
            DisplayBoard(board);

            int turnNum = 0;
            string player = "";
            bool exitGame = false;
            while (!exitGame)
            {
                Console.WriteLine();
                // if board is full, end game
                if (turnNum >= board.Count)
                {
                    exitGame = true;
                    Console.WriteLine("Reached board capacity, game over, it's a tie.");
                }
                // take turns between players x and o
                else
                {
                    if (turnNum % 2 == 0)
                    {
                        player = "x";
                        int index = PlayerTurn(board, player);
                        EditBoard(board, index, player);
                        DisplayBoard(board);
                        if (isWinner(board, player))
                        {
                            Console.WriteLine($"\nCongratulations, player {player} won!");
                            exitGame = true;
                        }
                    }
                    else
                    {
                        player = "o";
                        int index = PlayerTurn(board, player);
                        EditBoard(board, index, player);
                        DisplayBoard(board);
                        if (isWinner(board, player))
                        {
                            Console.WriteLine($"\nCongratulations, player {player} won!");
                            exitGame = true;
                        }
                    }
                }                
                // add iteration after every turn
                turnNum++;                                               
            }
            Console.WriteLine();
        }
    }
}
