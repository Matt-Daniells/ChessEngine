namespace Board
{
    // board generator containing the board grid with sentinel padding
    // the board uses a 10x12 array so boundary checks are easier and the playable area is 8x8
    public class BoardGen
    {
        // standard chess board size (8x8)
        const int BoardSize = 8;
        public Square[,] GeneratedBoard { get; private set; }

        public BoardGen()
        {
            // add sentinel squares around the playable board so out of bounds detection is easier
            GeneratedBoard = new Square[BoardSize + 4, BoardSize + 2];
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            // initialize all squares and mark them as invalid until the playable board is assigned
            for (int x = 0; x < BoardSize + 4; x++)
            {
                for (int y = 0; y < BoardSize + 2; y++)
                {
                    GeneratedBoard[x, y].SetValue(-1);
                }
            }

            // set values within the 8x8 board 0-63
            int i = 0;
            for (int x = 2; x < BoardSize + 2; x++)
            {
                for (int y = 1; y < BoardSize + 1; y++)
                {
                    GeneratedBoard[x, y].SetValue(i);
                    i++;
                }
            }
        }
        public int Size
        {
            // current board size for the playable area
            get { return BoardSize; }
        }

        public Square? LookupSquare(string rankAndFile)
        {
            if (string.IsNullOrWhiteSpace(rankAndFile) || rankAndFile.Length != 2)
            {
                return null;
            }

            int fileIndex = char.ToLowerInvariant(rankAndFile[0]) - 'a';
            int rankIndex = rankAndFile[1] - '1';

            if (fileIndex < 0 || fileIndex >= Size || rankIndex < 0 || rankIndex >= Size)
            {
                return null;
            }

            return GeneratedBoard[rankIndex + 2, fileIndex + 1];
        }
    }
}
