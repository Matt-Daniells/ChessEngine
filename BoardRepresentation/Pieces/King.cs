namespace Board.Pieces
{
    public class King : Piece
    {
        public King(string colour)
        : base(colour, PieceType.King) {}

        private const char WhiteUnicode = '\u2655';
        private const char BlackUnicode = '\u265B';
        
        // returns the unicode symbol for the piece
        public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
    }
}