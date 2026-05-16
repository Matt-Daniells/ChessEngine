namespace Board.Pieces
{
    public class King : Piece
    {
        public King(string colour)
        : base(colour, PieceType.King) {}

        private const char WhiteUnicode = '\u2654';
        private const char BlackUnicode = '\u265A';
        
        // returns the unicode symbol for the piece
        public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
    }
}