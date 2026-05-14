namespace Board.Pieces
{
    public class Pawn
    {
        private const char WhiteUnicode = '\u2659';
        private const char BlackUnicode = '\u265F';

        // returns the unicode symbol for the piece
        public static char Unicode(string colour)
            => colour == "WHITE" ? WhiteUnicode : BlackUnicode;
    }
}