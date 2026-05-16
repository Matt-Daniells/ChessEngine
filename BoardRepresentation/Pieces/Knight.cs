namespace Board.Pieces
{
    public class Knight : Piece
    {
        public Knight(string colour)
        : base(colour, PieceType.Knight) {}

        private const char WhiteUnicode = '\u2658';
        private const char BlackUnicode = '\u265E';
        
        // returns the unicode symbol for the piece
        public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
    }
}