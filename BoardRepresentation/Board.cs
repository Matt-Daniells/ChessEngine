namespace Board
{
    public class Board
    {
        // can use console inputs later for custom boardsizes?
        const int BOARD_SIZE = 8;
        public Square[,] generated_board;

        public Board()
        {
            generated_board = new Square[BOARD_SIZE, BOARD_SIZE];
            GenerateBoard();
        }

        // Look into using sentinels
        private void GenerateBoard()
        {
            for (int x=0; x < BOARD_SIZE; x++)
            {
                for (int y=0; y < BOARD_SIZE; y++)
                {
                    generated_board[x, y] = new Square(x, y);
                }
            }
        }
    }
}