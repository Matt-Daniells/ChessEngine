namespace Board
{
    public class BoardGen
    {
        // can use console inputs later for custom boardsizes?
        const int BOARD_SIZE = 8;
        public Square[,] generated_board;

        public BoardGen()
        {
            // Add Sentinel squares, make it 10x12
            generated_board = new Square[BOARD_SIZE+4, BOARD_SIZE+2];
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            //Initialise all squares, set value to -1
            for (int x = 0; x < BOARD_SIZE + 4; x++)
            {
                for (int y = 0; y < BOARD_SIZE + 2; y++)
                {
                    generated_board[x, y].SetValue(-1);
                }
            }
            
            // Set values within the 8x8 board
            int i=0;
            for (int x=2; x < BOARD_SIZE+2; x++)
            {
                for (int y=1; y < BOARD_SIZE+1; y++)
                {
                    generated_board[x, y].SetValue(i);
                    i++;
                }
            }
        }  
        public int Size
        {
            get { return BOARD_SIZE; }
        }
    }
}