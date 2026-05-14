using System.Runtime.CompilerServices;

namespace Board.Pieces
{
    public class Rook
    {
        private const char WhiteUnicode = '\u2656';
        private const char BlackUnicode = '\u265C';
        
        // returns the unicode symbol for the piece
        public static char Unicode(string colour)
            => colour == "WHITE" ? WhiteUnicode : BlackUnicode;
        
    }
}