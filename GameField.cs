using System;
using System.ComponentModel.Design.Serialization;

namespace TicTacToe
{
    public class GameField
    {
        public bool isFull = false;
        public char[,] states = new char[3, 3];
        public Player lastWinner;

        public char WinCheck(GameField board, Player player)
        {
            if (player.side == 'X' && (board.GetTurn(1, board) == 'X' && board.GetTurn(2, board) == 'X' &&
                                       board.GetTurn(3, board) == 'X') ||
                (board.GetTurn(1, board) == 'X' && board.GetTurn(4, board) == 'X' && board.GetTurn(7, board) == 'X') ||
                (board.GetTurn(1, board) == 'X' && board.GetTurn(5, board) == 'X' && board.GetTurn(9, board) == 'X') ||
                (board.GetTurn(3, board) == 'X' && board.GetTurn(6, board) == 'X' && board.GetTurn(9, board) == 'X') ||
                (board.GetTurn(4, board) == 'X' && board.GetTurn(5, board) == 'X' && board.GetTurn(6, board) == 'X') ||
                (board.GetTurn(3, board) == 'X' && board.GetTurn(5, board) == 'X' && board.GetTurn(7, board) == 'X') ||
                (board.GetTurn(7, board) == 'X' && board.GetTurn(8, board) == 'X' && board.GetTurn(9, board) == 'X') ||
                (board.GetTurn(2, board) == 'X' && board.GetTurn(5, board) == 'X' &&
                 board.GetTurn(8, board) == 'X')) return 'X';

            if (player.side == 'O' && (board.GetTurn(1, board) == 'O' && board.GetTurn(2, board) == 'O' &&
                                       board.GetTurn(3, board) == 'O') ||
                (board.GetTurn(1, board) == 'O' && board.GetTurn(4, board) == 'O' && board.GetTurn(7, board) == 'O') ||
                (board.GetTurn(1, board) == 'O' && board.GetTurn(5, board) == 'O' && board.GetTurn(9, board) == 'O') ||
                (board.GetTurn(3, board) == 'O' && board.GetTurn(6, board) == 'O' && board.GetTurn(9, board) == 'O') ||
                (board.GetTurn(4, board) == 'O' && board.GetTurn(5, board) == 'O' && board.GetTurn(6, board) == 'O') ||
                (board.GetTurn(3, board) == 'O' && board.GetTurn(5, board) == 'O' && board.GetTurn(7, board) == 'O') ||
                (board.GetTurn(7, board) == 'O' && board.GetTurn(8, board) == 'O' && board.GetTurn(9, board) == 'O') ||
                (board.GetTurn(2, board) == 'O' && board.GetTurn(5, board) == 'O' &&
                 board.GetTurn(8, board) == 'O')) return 'O';

            if (board.IsFull(board))
                return 'd';
            return '0';
        }

        public void Show()
        {
            for (int i = 0; i < states.GetLength(0); i++)
            {
                Console.Write("| ");
                for (int j = 0; j < states.GetLength(1); j++)
                    Console.Write(states[i, j] + " | ");
                Console.WriteLine();
            }
        }

        public char GetTurn(int state, GameField board)
        {
            if (state == 1) return board.states[0, 0];
            if (state == 2) return board.states[0, 1];
            if (state == 3) return board.states[0, 2];
            if (state == 4) return board.states[1, 0];
            if (state == 5) return board.states[1, 1];
            if (state == 6) return board.states[1, 2];
            if (state == 7) return board.states[2, 0];
            if (state == 8) return board.states[2, 1];
            if (state == 9) return board.states[2, 2];
            return 'n';
        }

        public bool IsFull(GameField board)
        {
            for (int t = 1; t < 10; t++)
                if (board.GetTurn(t, board) == '\0')
                    return false;
            return true;
        }

        public void ShowScore(Player player_1, Player player_2)
        {
            Console.WriteLine(player_1.name + " - " + player_1.score + " | " + player_2.name + " - " +
                              player_2.score);
        }
    }
}