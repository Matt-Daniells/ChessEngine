namespace Board.Pieces
{
    // Bishop piece implementation with Unicode symbols for white and black.
    public class Bishop : Piece
    {
        public Bishop(string colour)
        : base(colour, PieceType.Bishop) {}

        private const char WhiteUnicode = '\u2657';
        private const char BlackUnicode = '\u265D';

        // returns the unicode symbol for the piece
        public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
        
    }
}