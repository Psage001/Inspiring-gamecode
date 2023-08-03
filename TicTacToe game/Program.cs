using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            StartGame();
        }

        static void DisplayBoard()
        {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        static bool CheckWinner()
        {
            // Check rows, columns, and diagonals for a winner
            if ((board[0] == board[1] && board[1] == board[2] && board[0] != ' ') ||
                (board[3] == board[4] && board[4] == board[5] && board[3] != ' ') ||
                (board[6] == board[7] && board[7] == board[8] && board[6] != ' ') ||
                (board[0] == board[3] && board[3] == board[6] && board[0] != ' ') ||
                (board[1] == board[4] && board[4] == board[7] && board[1] != ' ') ||
                (board[2] == board[5] && board[5] == board[8] && board[2] != ' ') ||
                (board[0] == board[4] && board[4] == board[8] && board[0] != ' ') ||
                (board[2] == board[4] && board[4] == board[6] && board[2] != ' '))
            {
                return true;
            }

            return false;
        }

        static bool IsBoardFull()
        {
            return !Array.Exists(board, element => element == ' ');
        }

        static void MakeMove(int move)
        {
            if (board[move] == ' ')
            {
                board[move] = currentPlayer;
                DisplayBoard();

                if (CheckWinner())
                {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    ResetGame();
                }
                else if (IsBoardFull())
                {
                    Console.WriteLine("It's a draw!");
                    ResetGame();
                }
                else
                {
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                }
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }

        static void ResetGame()
        {
            board = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            currentPlayer = 'X';
            Console.WriteLine("Game has been reset. Starting a new game...");
            StartGame();
        }

        static void StartGame()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            DisplayBoard();

            while (true)
            {
                Console.Write($"Player {currentPlayer}, enter your move (0-8): ");
                int move;
                if (int.TryParse(Console.ReadLine(), out move) && move >= 0 && move < 9)
                {
                    MakeMove(move);
                }
                else
                {
                    Console.WriteLine("Invalid move. Please enter a number between 0 and 8.");
                }
            }
        }
    }
}
