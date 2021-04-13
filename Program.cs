using System;

namespace TicTacToe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char[,] orderField = new char[3, 3] {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};

            start:
            Console.WriteLine("\n1. Play with second person\n2. Play with computer\n3. Exit");
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    // first player init
                    Console.Write("Enter the name of first player: ");
                    string name_1 = Console.ReadLine();
                    Player player_1 = new Player(name_1, 0, 'n');
                    falseSide:
                    Console.WriteLine("Select your side\n1. X\n2. O");
                    int pSide = Convert.ToInt32(Console.ReadLine());
                    switch (pSide)
                    {
                        case 1:
                            player_1.side = 'X';
                            break;
                        case 2:
                            player_1.side = 'O';
                            break;
                        default:
                            goto falseSide;
                    }

                    // second player init
                    Console.Write("Enter the name of second player: ");
                    string name_2 = Console.ReadLine();
                    Player player_2 = new Player(name_2, 0, 'n');
                    if (player_1.side == 'X') player_2.side = 'O';
                    else player_2.side = 'X';

                    // start
                    GameField board = new GameField();
                    settingSide_1:
                    Console.Clear();
                    board.ShowScore(player_1, player_2);
                    Console.WriteLine(player_1.name + "'s turn. Choose the field");
                    board.Show();
                    int turn_1 = Convert.ToInt32(Console.ReadLine());
                    if (board.GetTurn(turn_1, board) == 'X' || board.GetTurn(turn_1, board) == 'O' ||
                        turn_1 < 1 || turn_1 > 9) goto settingSide_1;
                    player_1.SetTurn(turn_1, player_1, board);
                    char result = board.WinCheck(board, player_1);
                    if (result != '0') goto eofGame;

                    settingSide_2:
                    Console.Clear();
                    board.ShowScore(player_1, player_2);
                    Console.WriteLine(player_2.name + "'s turn. Choose the field");
                    board.Show();
                    int turn_2 = Convert.ToInt32(Console.ReadLine());
                    if (board.GetTurn(turn_2, board) == 'X' || board.GetTurn(turn_2, board) == 'O' ||
                        turn_2 < 1 || turn_2 > 9) goto settingSide_2;
                    player_1.SetTurn(turn_2, player_2, board);
                    result = board.WinCheck(board, player_2);
                    if (result != '0') goto eofGame;
                    goto settingSide_1;

                    eofGame:
                    Console.Clear();
                    board.ShowScore(player_1, player_2);
                    board.Show();
                    Console.WriteLine(result);
                    if (result == 'd') Console.WriteLine("DRAW");
                    else if (player_1.side == result)
                    {
                        Console.WriteLine(player_1.name + " win!");
                        board.lastWinner = player_1;
                        player_1.score++;
                    }
                    else
                    {
                        Console.WriteLine(player_2.name + " win!\n");
                        board.lastWinner = player_2;
                        player_2.score++;
                    }

                    Console.WriteLine("New game? 1. Yes 2. No");
                    int newGame = Convert.ToInt32(Console.ReadLine());
                    if (newGame == 1)
                    {
                        board.states = new char[3, 3];
                        if (board.lastWinner == player_1) goto settingSide_1;
                        goto settingSide_2;
                    }

                    break;
                case 2:
                    break;
                default:
                    goto start;
            }
        }
    }
}