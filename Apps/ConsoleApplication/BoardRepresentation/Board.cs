namespace Board;

// board generator containing the board grid with sentinel padding
// the board uses a 10x12 array so boundary checks are easier and the playable area is 8x8
public class BoardGen
{
    // standard chess board size (8x8)
    private const int BoardSize = 8;
    private const int HeightPadding = 4;
    private const int WidthPadding = 2;

    public Square[,] GeneratedBoard { get; private set; } = null!;
    public int Size => BoardSize;

    public BoardGen() => GenerateBoard();

    private void GenerateBoard()
    {
        GeneratedBoard = new Square[BoardSize + HeightPadding, BoardSize + WidthPadding];
        InitialiseSentinelValues();
        InitialisePlayableBoardValues();
    }

    private void InitialiseSentinelValues()
    {
        // initialise all squares and mark them as invalid until the playable board is assigned
        for (int x = 0; x < BoardSize + HeightPadding; x++)
        {
            for (int y = 0; y < BoardSize + WidthPadding; y++)
            {
                GeneratedBoard[x, y].SetValue(-1);
            }
        }
    }

    private void InitialisePlayableBoardValues()
    {
        // set values within the 8x8 playable board 0-63
        int i = 0;
        for (int x = 2; x < BoardSize + (HeightPadding / 2); x++)
        {
            for (int y = 1; y < BoardSize + (WidthPadding / 2); y++)
            {
                GeneratedBoard[x, y].SetValue(i);
                i++;
            }
        }
    }

    public Square? LookupSquare(string rankAndFile)
    {
        if (string.IsNullOrWhiteSpace(rankAndFile) || rankAndFile.Length != 2)
        {
            return null;
        }

        int fileIndex = char.ToLowerInvariant(rankAndFile[0]) - 'a';
        int rankIndex = rankAndFile[1] - '1';
        // validate bounds: return null if out of playable range
        return SquareOutOfBounds(fileIndex, rankIndex) ? null : GeneratedBoard[rankIndex + (HeightPadding / 2), fileIndex + (WidthPadding / 2)];
    }

    public bool SquareOutOfBounds(int fileIndex, int rankIndex) => fileIndex < 0 || fileIndex >= Size || rankIndex < 0 || rankIndex >= Size;

}
