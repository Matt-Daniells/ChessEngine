namespace Board;

// represents a single board square including position, occupancy, and metadata
// the struct is used inside the board array for fast access
public struct Square(int rank, int file)
{
    public int Rank = rank;
    public int File = file;
    public int Value = -1;

    public Piece? Piece { get; set; }

    // set a unique numeric value for this square for board indexing (0-63 or -1)
    public void SetValue(int value) => Value = value;

    // return a chessboard style value for each square i.e a1
    public readonly string DisplayLocation() => $"{(char)('a' + File)}{Rank + 1}";

    // true when a piece is present on this square
    public readonly bool IsOccupied() => Piece != null;
}
