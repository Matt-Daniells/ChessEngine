namespace Board;

// represents all supported chess piece types
public enum PieceType
{
    Queen,
    Pawn,
    King,
    Knight,
    Rook,
    Bishop
}

// base class for all chess pieces, holds type and color
public abstract class Piece(string colour, PieceType type)
{

    // U=unicode symbol used for console rendering
    public abstract char Unicode { get; }

    // returns the piece color string, e.g. "WHITE" or "BLACK"
    public string Colour { get; } = colour;

    // rturns the piece type enum for this piece
    public PieceType Type { get; } = type;
}
