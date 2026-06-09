namespace Board;

public class Move
{
    public BoardGen Board { get; }
    public string Notation { get; }

    public Move(BoardGen board, string notation)
    {
        Board = board ?? throw new ArgumentNullException(nameof(board));
        Notation = notation ?? throw new ArgumentNullException(nameof(notation));
        //SplitNotation();
        foreach (string chunk in SplitNotation())
        {
            if (chunk.Length > 2)
            {
                string squareString = chunk[1].ToString() + chunk[2];
                object? squareObj = Board.LookupSquare(squareString);
                if (squareObj is not null)
                {
                    Square square = (Square)squareObj;
                    char piece = chunk[0];
                    Console.WriteLine(CheckOccupation(piece, square).ToString());
                }
            }
        }
    }

    private List<string> SplitNotation()
    {
        char[] splitters = ['x', '+', '='];
        List<string> chunks = [.. Notation.Split(splitters)];

        foreach (char c in Notation)
        {
            if (splitters.Contains(c)) { chunks.Add(c.ToString()); }
        }

        return chunks;
    }

    /* private bool Castling() => Notation[0] == 'O';

    private string CastlingDirection()
    {
        string side = SplitNotation().Count > 2
        ? "Queen"
        : "King";

        return side;
    } */

    private bool CheckOccupation(char piece, Square square)
    {
        if (square.IsOccupied() && square.Piece is not null)
        {
            string typeString = square.Piece.Type.ToString();
            return char.ToUpperInvariant(typeString[0]) == char.ToUpperInvariant(piece);
        }
        return false;
    }
}
