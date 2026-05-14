namespace Board.Pieces
{
    public class Bishop
    {
        private const char WhiteUnicode = '\u2657';
        private const char BlackUnicode = '\u265D';

        // returns the unicode symbol for the piece
        public static char Unicode(string colour)
            => colour == "WHITE" ? WhiteUnicode : BlackUnicode;
        
    }
}