namespace Board.Pieces
{
    public class Knight
    {
        private const char WhiteUnicode = '\u2655';
        private const char BlackUnicode = '\u265B';
        
        // returns the unicode symbol for the piece
        public static char Unicode(string colour)
            => colour == "WHITE" ? WhiteUnicode : BlackUnicode;
    }
}