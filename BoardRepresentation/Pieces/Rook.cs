namespace Board.Pieces
{
    public class Rook : Piece
    {
        public Rook(string colour)
        : base(colour, PieceType.Rook) {}

        private const char WhiteUnicode = '\u2656';

        private const char BlackUnicode = '\u265C';
        
        // returns the unicode symbol for the piece
        public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
        
    }
}