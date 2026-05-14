namespace Board.Pieces
{
    public class Knight : Piece
    {
        public Knight(string colour)
        : base(colour, PieceType.Knight) {}

        private const char WhiteUnicode = '\u2655';
        private const char BlackUnicode = '\u265B';
        
        // returns the unicode symbol for the piece
        public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
    }
}