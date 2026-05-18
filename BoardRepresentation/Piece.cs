namespace Board
{
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
    public abstract class Piece
    {
        private readonly string piece_colour;
        private readonly PieceType piece_type;
        // U=unicode symbol used for console rendering
        public abstract char Unicode { get; }

        protected Piece(string colour, PieceType type)
        {
            piece_colour = colour;
            piece_type = type;
        }

        // returns the piece color string, e.g. "WHITE" or "BLACK"
        public string Colour => piece_colour;

        // rturns the piece type enum for this piece
        public PieceType Type => piece_type;
    }
}