namespace Board.Pieces
{
    public class Queen : Piece
    {
        public Queen(string colour)
        : base(colour, PieceType.Queen) {}

        private const char WhiteUnicode = '\u2655';
        private const char BlackUnicode = '\u265B';
        
        // returns the unicode symbol for the piece
        public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
    }
}