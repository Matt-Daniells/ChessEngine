namespace Board
{
    public enum PieceType
    {
        Queen,
        Pawn,
        King,
        Knight,
        Rook,
        Bishop
    }

    public abstract class Piece
    {
        private readonly string piece_colour;
        private readonly PieceType piece_type;
        public abstract char Unicode { get; }

        protected Piece(string colour, PieceType type)
        {
            piece_colour = colour;
            piece_type = type;
        }

        // returns the colour as the property Colour on the class
        public string Colour => piece_colour;

        public PieceType Type => piece_type;
    }
}