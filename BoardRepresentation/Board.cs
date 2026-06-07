namespace Board
{
    // board generator containing the board grid with sentinel padding
    // the board uses a 10x12 array so boundary checks are easier and the playable area is 8x8
    public class BoardGen
    {
        // standard chess board size (8x8)
        const int BOARD_SIZE = 8;
        public Square[,] generated_board;

        public BoardGen()
        {
            // add sentinel squares around the playable board so out of bounds detection is easier
            generated_board = new Square[BOARD_SIZE+4, BOARD_SIZE+2];
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            // initialize all squares and mark them as invalid until the playable board is assigned
            for (int x = 0; x < BOARD_SIZE + 4; x++)
            {
                for (int y = 0; y < BOARD_SIZE + 2; y++)
                {
                    generated_board[x, y].SetValue(-1);
                }
            }
            
            // set values within the 8x8 board 0-63
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
            // current board size for the playable area
            get { return BOARD_SIZE; }
        }

        public Square? LookupSquare(string rank_and_file)
        {
            if (string.IsNullOrWhiteSpace(rank_and_file) || rank_and_file.Length != 2)
            {
                return null;
            }

            int file_index = char.ToLowerInvariant(rank_and_file[0]) - 'a';
            int rank_index = rank_and_file[1] - '1';

            if (file_index < 0 || file_index >= Size || rank_index < 0 || rank_index >= Size)
            {
                return null;
            }

            return generated_board[rank_index + 2, file_index + 1];
        }
    }
}