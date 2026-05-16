namespace Board.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(string colour)
        : base(colour, PieceType.Pawn) {}

        private const char WhiteUnicode = '\u2659';
        private const char BlackUnicode = '\u265F';

        // returns the unicode symbol for the piece
        public override char Unicode => Colour == "WHITE" ? WhiteUnicode : BlackUnicode;
    }
}