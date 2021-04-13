namespace TicTacToe
{
    public class Player
    {
        public string name;
        public int score;
        public char side;

        public Player(string pName, int pScore, char pSide)
        {
            this.name = pName;
            this.score = pScore;
            this.side = pSide;
        }

        public void SetTurn(int state, Player player, GameField board)
        {
            if (state == 1) board.states[0, 0] = player.side;
            if (state == 2) board.states[0, 1] = player.side;
            if (state == 3) board.states[0, 2] = player.side;
            if (state == 4) board.states[1, 0] = player.side;
            if (state == 5) board.states[1, 1] = player.side;
            if (state == 6) board.states[1, 2] = player.side;
            if (state == 7) board.states[2, 0] = player.side;
            if (state == 8) board.states[2, 1] = player.side;
            if (state == 9) board.states[2, 2] = player.side;
        }
        
    }
}